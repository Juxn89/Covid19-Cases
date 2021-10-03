using Covid19_Cases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covid19_Cases.Helpers
{
    public static class HTMLHelpers
    {
        public static List<SelectListItem> ConvertoToSelectListItem(this List<DataDto> data) {
            return data.Select(a => new SelectListItem { Value = a.name, Text = a.name }).ToList();
        }
    }
}