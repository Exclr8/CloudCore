using System;
using Frameworkone.Caching;

namespace Frameworkone.UnitTestUtilities.Cache
{
    /// <summary>
    /// Use this class if you want to fake/stub/filter out cache life time policies
    /// </summary>
    public class CachePolicyFake : ICacheLifeTimePolicy
    {
        public void Initialise()
        {

        }

        public TimeSpan? GetLifeTime<T>(T type)
        {
            return new TimeSpan(0, 0, 1, 0);
        }
    }
}