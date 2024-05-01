using System.Diagnostics;
using FinancialApp.Web.DB;
using Microsoft.AspNetCore.Mvc;
using FinancialApp.Web.Models;
using FinancialApp.Web.Repositories;
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

    private readonly ITransactionRepository transactionRepository;

    public HomeController(ITransactionRepository transactionRepository)
    {
        this.transactionRepository = transactionRepository;
    }

    public IActionResult Index(int? month)
    {
        var currentMonth = month != null ? month.GetValueOrDefault() : DateTime.Now.Month;
        var transactions = transactionRepository.GetTransactionsByMonth(currentMonth);
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