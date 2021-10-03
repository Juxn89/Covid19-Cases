using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19_Cases.DTO
{
    /// <summary>
    /// Region DTO
    /// </summary>
    public class RegionDto
    {
        public List<DataDto> data { get; set; }
    }

    public class DataDto {
        /// <summary>
        /// Region's ISO
        /// </summary>
        public string iso { get; set; }

        /// <summary>
        /// Regions's name
        /// </summary>
        public string name { get; set; }
    }
}