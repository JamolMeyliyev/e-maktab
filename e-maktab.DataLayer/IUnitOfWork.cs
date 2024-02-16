using e_maktab.DataLayer.Context;
using Microsoft.EntityFrameworkCore.Storage;


namespace e_maktab.DataLayer;

public interface IUnitOfWork
{
    EMaktabContext Context { get; }
    IDbContextTransaction CurrentTransaction { get; }
    TRepository GetRepository<TRepository>();
    IDbContextTransaction BeginTransaction();
    void Save();
    void Commit();
    void Rollback();
}
