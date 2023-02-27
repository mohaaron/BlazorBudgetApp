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

namespace BudgetApp.Client.Components.DialogWindows
{
    public partial class IncomeForm
    {
        [Inject] private IHttpClientRepository<Income> repository { get; set; }

        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter] public Income Income { get; set; } = new();

        [Parameter] public ICollection<Income> Paychecks { get; set; }

        private Income validate { get; set; } = new();

        protected override Task OnInitializedAsync()
        {
            if (Income is not null)
            {
                //validate = EntityHelper.Clone<Income>(Income);
                validate = new Income
                {
                    Id = Income.Id,
                    Amount = Income.Amount,
                    PayDate = Income.PayDate,
                    Source = Income.Source,
                };
			}

            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            // What do we use this for?

            return base.OnParametersSetAsync();
        }

        async Task Save()
        {
            await BlazoredModal.CloseAsync(ModalResult.Ok<Income>(validate));
        }

        async Task Cancel() => await BlazoredModal.CancelAsync();
    }
}