using FinancialApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace FinancialApp.Test.Controllers;

public class HomeControllerTest
{
    [Test]
    public void TestIndexCase01()
    {
        var controller = new HomeController(null);
        var result = controller.Index() as ViewResult;
        
        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsNull(result.Model);
    }

    public void TestPrivacyCase01()
    {
        var controller = new HomeController(null);
        var result = controller.Privacy() as ViewResult;;
        
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsNull(result.Model);
    }
}