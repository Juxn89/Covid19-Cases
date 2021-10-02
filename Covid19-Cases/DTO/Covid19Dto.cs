using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19_Cases.DTO
{
    /// <summary>
    /// Report DTO 
    /// </summary>
    public class Covid19Dto
    {
        /// <summary>
        /// Total of region's death
        /// </summary>
        public int deaths { get; set; }

        /// <summary>
        /// Total cases confirmed by region
        /// </summary>
        public int confirmed { get; set; }

        /// <summary>
        /// Region's name
        /// </summary>
        public string province { get; set; }
    }
}