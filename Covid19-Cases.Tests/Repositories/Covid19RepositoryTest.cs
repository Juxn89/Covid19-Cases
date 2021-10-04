using Covid19_Cases.DTO;
using Covid19_Cases.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Covid19_Cases.Repositories.Tests
{
    [TestClass()]
    public class Covid19RepositoryTest
    {
        private Covid19Repository _covidRepository = new Covid19Repository();
        [TestMethod()]
        public void GetRegionsAsyncTest()
        {
            var data = _covidRepository.GetRegionsAsync().Result;
            Assert.IsNotNull(data);
            Assert.AreEqual(data.Count, 216);
            CollectionAssert.AllItemsAreUnique(data);
            CollectionAssert.AllItemsAreInstancesOfType(data, typeof(SelectListItem));
        }
        
        [TestMethod()]
        public void GetReportAsyncTest()
        {
            var data = _covidRepository.GetReportAsync().Result;
            Assert.IsNotNull(data);
            Assert.AreEqual(data.Count, 10);
            CollectionAssert.AllItemsAreUnique(data);
            CollectionAssert.AllItemsAreInstancesOfType(data, typeof(DataReportDto));
        }

        [TestMethod()]
        public void GetReportAsyncWithParamBlankTest()
        {
            var data = _covidRepository.GetReportAsync("").Result;
            Assert.IsNotNull(data);
            Assert.AreEqual(data.Count, 10);
            CollectionAssert.AllItemsAreUnique(data);
            CollectionAssert.AllItemsAreInstancesOfType(data, typeof(DataReportDto));
        }

        [TestMethod()]
        public void GetReportAsyncWithParamTest()
        {
            var data = _covidRepository.GetReportAsync("US").Result;
            Assert.IsNotNull(data);
            Assert.AreEqual(data.Count, 10);
            CollectionAssert.AllItemsAreUnique(data);
            CollectionAssert.AllItemsAreInstancesOfType(data, typeof(DataReportDto));
        }
        
        [TestMethod()]
        public void GenerateFileTest()
        {
            var data = _covidRepository.GenerateFile(1).Result;
            Assert.IsNotNull(data);
            CollectionAssert.AllItemsAreInstancesOfType(data, typeof(byte));
        }
    }
}
