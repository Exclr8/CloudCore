using System;
using System.Linq;
using CloudCore.Core.Caching;

namespace Frameworkone.UnitTestUtilities.Cache
{
    /// <summary>
    /// Use this class if you specifically want to check (test) what is happening to production cache life time policies
    /// </summary>
    public class CachePolicyMock : CloudCoreCacheLifeTimePolicy
    {
        public CachePolicyMock()
        {
            if (policies.Any(p => p.Value.Invoke().Ticks == 0))
                // TODO: Not tested with InMemoryCacheProvider yet. InMemoryCacheProvider is not yet intentionally used in production.
                throw new Exception("Azure Caching does not allow cache life-times (expiry-times) of zero (0).");
        }
    }
}
