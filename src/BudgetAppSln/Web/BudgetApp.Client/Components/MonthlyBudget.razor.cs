using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Blazored.Modal;
using Blazored.Modal.Services;
using BudgetApp.Data.Models;
using BudgetApp.Data.Repositories.Interfaces;
using BudgetApp.Client.Components.DialogWindows;
using Fluxor; // In Imports, should not be needed here
using BudgetApp.Client.Shared.FluxStore.TopToolbar; // In Imports, should not be needed here
using Toolbelt.Blazor.HotKeys2;
using System;

namespace BudgetApp.Client.Components
{
    public partial class MonthlyBudget : IDisposable
    {
        [Inject]
        private IDispatcher _dispatcher { get; set; }
        [Inject]
        private HotKeys HotKeys { get; set; }
        private HotKeysContext _hotKeysContext;

        [Inject]
        private IHttpClientRepository<Budget> budgetRepository { get; set; }
        [Inject]
        private IHttpClientRepository<Expense> expenseRepository { get; set; }
        [Inject]
        private IHttpClientRepository<Income> incomeRepository { get; set; }

        [Parameter] public Budget Budget { get; set; }

        [CascadingParameter] public IModalService Modal { get; set; }

        private string title { get; set; }

        protected override Task OnInitializedAsync()
        {
            _dispatcher.Dispatch(new TopToolbarAction("Title"));
            _hotKeysContext = HotKeys.CreateContext()
                .Add(ModCode.Ctrl, Code.A, async () => await AddExpenseAsync(), description: "Add new expense.");

            //DateOnly date = DateOnly.FromDateTime(StartDate);
            //int id = 20216;
            //var Budget = await repository.GetBudget(id);

            title = Budget.Id.ToString().Insert(4, "-");

			return base.OnInitializedAsync();
		}

        private async Task AddExpenseAsync()
        {
            ModalParameters parameters = new ModalParameters();
            parameters.Add("Paychecks", Budget.Incomes);

            IModalReference modal = Modal.Show<ExpenseForm>("Add Expense", parameters);
            var win = await modal.Result;

            if (!win.Cancelled)
            {
                Expense expense = (Expense)win.Data;
                expense.BudgetId = Budget.Id;

                var db = await expenseRepository.Create(expense);
                if (db.StatusCode == HttpStatusCode.OK)
                {
                    Budget = await budgetRepository.Get(Budget.Id);
                }
            }
        }

        private async Task EditExpenseAsync(Expense expense)
        {
			ModalParameters parameters = new ModalParameters();
            parameters.Add("Expense", expense);
            parameters.Add("Paychecks", Budget.Incomes);

            var form = Modal.Show<ExpenseForm>("Edit Expense", parameters);
            var win = await form.Result;

            if (!win.Cancelled)
            {
                Expense updatedExpense = (Expense)win.Data;

                var db = await expenseRepository.Update(updatedExpense);
                if (db.StatusCode == HttpStatusCode.OK)
				{
                    Budget = await budgetRepository.Get(Budget.Id);
                }
            }
        }

        HashSet<int> expensesToDelete = new HashSet<int>();
		private void ExpenseCheckChanged(ChangeEventArgs e, int id)
        {
            if (expensesToDelete.Contains(id))
                expensesToDelete.Remove(id);
            else
                expensesToDelete.Add(id);
        }

        private async Task DeleteExpenseAsync()
        {
            if (expensesToDelete.Count > 0)
            {
                foreach (int id in expensesToDelete)
                {
                    var expense = Budget.Expenses.SingleOrDefault(e => e.Id == id);
                  
                    var response = await expenseRepository.Delete(id);
                    if (response.StatusCode == HttpStatusCode.OK)
                        Budget = await budgetRepository.Get(Budget.Id);
                }
            }
        }

        private async Task EditIncomeAsync(Income income)
        {
            ModalParameters parameters = new ModalParameters();
            parameters.Add("Income", income);
            parameters.Add("Paychecks", Budget.Incomes);

            var form = Modal.Show<IncomeForm>("Edit Income", parameters);
            var win = await form.Result;

            if (!win.Cancelled)
            {
                Income updatedIncome = (Income)win.Data;

                var db = await incomeRepository.Update(updatedIncome);
                if (db.StatusCode == HttpStatusCode.OK)
                {
                    Budget = await budgetRepository.Get(Budget.Id);
                }
            }
        }

        public void Dispose()
        {
            _hotKeysContext.Dispose();
        }
    }
}