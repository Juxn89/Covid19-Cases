using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19_Cases.DTO
{
    public class CovidCasesDto
    {
        public bool isFilter { get; set; } = false;
        public List<DataDto> lstRegion { get; set; }
        public List<DataReportDto> lstDetail { get; set; }
    }
}