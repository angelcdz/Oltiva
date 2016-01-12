using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using AppInsurance.DAO;
using AppInsurance.DTO.GetInsurances;

namespace AppInsuranceUnitTests
{
    [TestClass]
    public sealed class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dao = new GetInsurancesDAO();
            dao.Execute(new GetInsurancesRequest());
        }
    }
}
