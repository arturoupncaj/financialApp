using System.Collections.Generic;
using FinancialApp.Web.Controllers;
using FinancialApp.Web.Models;
using FinancialApp.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace FinancialApp.Test.Controllers;

public class FakeTransactionRepository : ITransactionRepository
{
    public List<Transaccion> GetTransactionsByMonth(int month)
    {
        return new List<Transaccion>()
        {
            new Transaccion {CuentaId = 1, Monto = 10m, Tipo = "INGRESO"},
            new Transaccion {CuentaId = 1, Monto = 10m, Tipo = "INGRESO"},
        };
    }
}

public class HomeControllerTest
{
    [Test]
    public void TestIndexCase01()
    {
        var repo = new FakeTransactionRepository();
        var controller = new HomeController(repo);
        var result = controller.Index(null) as ViewResult;
        
        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsNotNull(result.Model);
    }

    public void TestPrivacyCase01()
    {
        var controller = new HomeController(null);
        var result = controller.Privacy() as ViewResult;;
        
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsNull(result.Model);
    }
}