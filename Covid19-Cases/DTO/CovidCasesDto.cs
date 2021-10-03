using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covid19_Cases.DTO
{
    public class CovidCasesDto
    {
        public bool isFilter { get; set; } = false;
        public string region { get; set; } = null;
        public List<SelectListItem> lstRegion { get; set; }
        public List<DataReportDto> lstDetail { get; set; }
    }
}