using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using Blazored.Modal;
using Blazored.Modal.Services;
using BudgetApp.Client;
using BudgetApp.Client.Shared;
using BudgetApp.Data.Models;
using BudgetApp.Client.Shared;
using BudgetApp.Data.Repositories.Interfaces;
using BudgetApp.Shared;
using AutoMapper;

namespace BudgetApp.Client.Components.DialogWindows
{
    public partial class ExpenseForm
    {
        [Inject] private IHttpClientRepository<Expense> expenseRepository { get; set; }

        [Inject] private IMapper mapper { get; set; }

        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter] public Expense Expense { get; set; } = new();

        [Parameter] public ICollection<Income> Paychecks { get; set; }

        private Expense validateExpense { get; set; } = new();

        private int paycheckId { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (Expense is not null)
            {
                paycheckId = Expense.IncomeId != null ? Expense.IncomeId.Value : 0;
                validateExpense = mapper.Map<Expense>(Expense);
            }
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        async Task Save()
        {
            if (paycheckId == 0)
                validateExpense.IncomeId = null;
            else
                validateExpense.IncomeId = paycheckId;
          
            await BlazoredModal.CloseAsync(ModalResult.Ok<Expense>(validateExpense));
        }

        async Task Cancel() => await BlazoredModal.CancelAsync();
    }
}