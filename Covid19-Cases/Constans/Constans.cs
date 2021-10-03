using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19_Cases.Constans
{
    /// <summary>
    /// Constans
    /// </summary>
    public static class Constans
    {
        /// <summary>
        /// Base URL to be used by endpoints
        /// </summary>
        private static readonly string BASE_URL = "https://covid-19-statistics.p.rapidapi.com";

        /// <summary>
        /// Region's endpoint
        /// </summary>
        public static readonly string REGION_ENDPOINT = $"{BASE_URL}/regions";

        /// <summary>
        /// Report's endpoint
        /// </summary>
        public static readonly string REPORT_ENDPOINT = $"{BASE_URL}/reports";
    }
}