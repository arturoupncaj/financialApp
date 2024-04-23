using FinancialApp.Web.Controllers;
using FinancialApp.Web.DB;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace FinancialApp.Test.Controllers;

public class CuentaControllerTest
{
    [Test]
    public void TestIndexCase01()
    {
        var dbEntities = new DbEntities();
        var controller = new CuentaController(null, dbEntities);
        var result = controller.Index("") as ViewResult;
        
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsNull(result.Model);
    }
}