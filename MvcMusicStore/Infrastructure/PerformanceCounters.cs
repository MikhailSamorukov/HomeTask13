using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using PerformanceCounterHelper;

namespace MvcMusicStore.Infrastructure
{
    [PerformanceCounterCategory("MvcMusicStore", PerformanceCounterCategoryType.MultiInstance, "MvcMusicStore")]
    public enum PerformanceCounters
    {
        [PerformanceCounter("Success Log In", "Count of success login in system", PerformanceCounterType.NumberOfItems32)]
        SuccessLogIn,
        [PerformanceCounter("Success Log of", "Count of success logof in system", PerformanceCounterType.NumberOfItems32)]
        SuccessLogOf,
        [PerformanceCounter("StartApplication", "Count of start application", PerformanceCounterType.NumberOfItems32)]
        StartApplication
    }
}