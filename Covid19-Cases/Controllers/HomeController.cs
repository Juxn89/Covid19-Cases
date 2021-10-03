using Covid19_Cases.DTO;
using Covid19_Cases.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Covid19_Cases.Controllers
{
    public class HomeController : Controller
    {
        private Coviv19Repository _CovidReporistory;

        public HomeController()
        {
            _CovidReporistory = new Coviv19Repository();
        }

        [HttpGet]
        public async Task<ActionResult> Index(string region)
        {
            var dataRegion = await _CovidReporistory.GetRegions();
            var detail = await _CovidReporistory.GetReport(region);

            var model = new CovidCasesDto()
            {
                isFilter = region == null ? false : true,
                lstRegion = dataRegion,
                lstDetail = detail
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Download()
        {
            return View();
        }
    }
}
