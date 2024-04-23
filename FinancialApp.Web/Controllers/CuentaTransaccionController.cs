using FinancialApp.Web.DB;
using FinancialApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Web.Controllers;

public class CuentaTransaccionController : Controller
{
    private DbEntities dbEntities;
    public CuentaTransaccionController(DbEntities dbEntities)
    {
        this.dbEntities = dbEntities;
    }
    
    [HttpGet]
    public IActionResult Index(int cuentaId)
    {
        var items = dbEntities.Transacciones.Where(o => o.CuentaId == cuentaId).ToList();
        ViewBag.CuentaId = cuentaId;
        ViewBag.Total = items.Any() ? items.Sum(x => x.Monto) : 0;

        return View(items);
    }
    
    [HttpGet]
    public IActionResult Create(int cuentaId)
    {
        ViewBag.CuentaId = cuentaId;
        return View(new Transaccion());
    }
    
    [HttpPost]
    public IActionResult Create(int cuentaId, Transaccion transaccion)
    {
        transaccion.CuentaId = cuentaId;
        if (transaccion.Tipo == "GASTO")
            transaccion.Monto *= -1;
        
        dbEntities.Transacciones.Add(transaccion);
        dbEntities.SaveChanges();

        return RedirectToAction("Index", new { cuentaId = cuentaId});
    }
    
   
}