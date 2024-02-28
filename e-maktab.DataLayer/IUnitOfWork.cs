using e_maktab.DataLayer.Context;
using Microsoft.EntityFrameworkCore.Storage;


namespace e_maktab.DataLayer;

public interface IUnitOfWork
{
    IDbContextTransaction CurrencyTransaction { get; }
    IDbContextTransaction BeginTransaction();
    void Commit();
    void Rollback();
}
