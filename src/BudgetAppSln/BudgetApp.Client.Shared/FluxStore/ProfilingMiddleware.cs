using Fluxor;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Client.Shared.FluxStore
{
    public class ProfilingMiddleware : Middleware
    {
        private readonly ConcurrentDictionary<object, DateTime> ActionTimes = new ConcurrentDictionary<object, DateTime>();

        public override void BeforeDispatch(object action)
        {
            base.BeforeDispatch(action);
            ActionTimes[action] = DateTime.UtcNow;
        }

        public override void AfterDispatch(object action)
        {
            base.AfterDispatch(action);
            if (ActionTimes.TryRemove(action, out DateTime startTime))
            {
                TimeSpan elapsed = DateTime.UtcNow - startTime;
                System.Diagnostics.Debug.WriteLine($"Action: {action.GetType().Name} took {elapsed}");
            }
        }
    }
}
