using Blazored.Modal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Shared
{
    public class ViewModelBase
    {
        public bool IsBusy { get; protected set; }
        public Action StateChanged { get; set; }
        protected IModalService ModalService { get; }

        public ViewModelBase()
        {
            //
        }
    }
}
