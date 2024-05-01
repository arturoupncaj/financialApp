using FinancialApp.Web.DB;
using FinancialApp.Web.Models;

namespace FinancialApp.Web.Repositories;


public interface ITransactionRepository
{
    List<Transaccion> GetTransactionsByMonth(int month);
}

public class TransactionRepository : ITransactionRepository
{
    private readonly DbEntities dbEntities;

    public TransactionRepository(DbEntities dbEntities)
    {
        this.dbEntities = dbEntities;
    }

    public List<Transaccion> GetTransactionsByMonth(int month)
    {
        var transactions = dbEntities.Transacciones
            .Where(o => o.Fecha.Month == month)
            .OrderByDescending(o => o.Fecha)
            .ToList();
        
        return transactions;
    }
}