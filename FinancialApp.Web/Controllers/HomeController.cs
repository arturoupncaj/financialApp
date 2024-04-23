using System.Diagnostics;
using FinancialApp.Web.DB;
using Microsoft.AspNetCore.Mvc;
using FinancialApp.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinancialApp.Web.Controllers;

[Authorize]
public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger;
    //
    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }
    
    private DbEntities dbEntities;

    // public HomeController()
    // {
    //     
    // }

    public HomeController(DbEntities dbEntities)
    {
        this.dbEntities = dbEntities;
    }

    public IActionResult Index()
    {
        var currentMonth = DateTime.Now.Month;
        var transactions = dbEntities.Transacciones
            .Where(o => o.Fecha.Month == currentMonth)
            .OrderByDescending(o => o.Fecha)
            .ToList();
        return View(transactions);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}