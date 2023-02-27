using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Client.Shared.FluxStore.TopToolbar
{
    [FeatureState]
    public class TopToolbarState
    {
        public string Title { get; }

        public TopToolbarState() { }

        public TopToolbarState(string title)
        {
            Title = title;
        }
    }
}
