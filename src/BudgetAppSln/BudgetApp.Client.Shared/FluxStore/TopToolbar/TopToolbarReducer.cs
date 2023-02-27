using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Client.Shared.FluxStore.TopToolbar
{
    public static class TopToolbarReducer
    {
        [ReducerMethod]
        public static TopToolbarState ReduceTopToolbarTitleAction(TopToolbarState state, TopToolbarAction action) =>
            new(title: action.Title);
    }
}
