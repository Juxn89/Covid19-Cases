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
        private FileRopository _fileRepository;

        public HomeController()
        {
            _fileRepository = new FileRopository();
            _CovidReporistory = new Coviv19Repository();
        }

        [HttpGet]
        public async Task<ActionResult> Index(string region)
        {
            if (string.IsNullOrEmpty(region) || string.IsNullOrWhiteSpace(region))
                region = null;

            var dataRegion = await _CovidReporistory.GetRegionsAsync();
            var detail = await _CovidReporistory.GetReportAsync(region);

            var model = new CovidCasesDto()
            {
                isFilter = region == null ? false : true,
                region = region,
                lstRegion = dataRegion,
                lstDetail = detail
            };

            return View(model);
        }

        [HttpGet]
        public async Task<FileResult> Download(int typeFile, string region)
        {
            byte[] fileContent;
            string contentType = string.Empty;
            string fileName = "Covid-19Cases";

            var info = _fileRepository.GetInfoFileExport(typeFile);
            fileName = $"{fileName}{info.extensionFile}";
            contentType = info.ContentType;

            fileContent = await _CovidReporistory.GenerateFile(typeFile, region);

            return File(fileContent, contentType, fileName);
        }
    }
}
