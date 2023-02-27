using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Client.Shared.FluxStore.TopToolbar
{
    public class TopToolbarAction
    {
        public string Title { get; }

        public TopToolbarAction(string title)
        {
            Title = title;
        }
    }
}
