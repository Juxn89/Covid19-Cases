using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Covid19_Cases;
using Covid19_Cases.Controllers;
using System.Threading.Tasks;

namespace Covid19_Cases.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            string region = null;

            HomeController controller = new HomeController();                        
            Task<ActionResult> result = controller.Index(region) as  Task<ActionResult>;

            var viewResult = result.Result;
            
            Assert.IsNotNull(result);
        }
    }
}
