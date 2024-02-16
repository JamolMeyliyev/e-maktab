using e_maktab.DataLayer.Context;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.DataLayer;

public class UnitOfWork : IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    public  EMaktabContext Context { get; }
    public UnitOfWork(IServiceProvider serviceProvider,EMaktabContext _Context)
    {
        Context = _Context;
        
        _serviceProvider = serviceProvider;
    }

   
    
    public IDbContextTransaction CurrentTransaction { get => Context.Database.CurrentTransaction; }
    public TRepository GetRepository<TRepository>() => _serviceProvider.GetRequiredService<TRepository>();

    public IDbContextTransaction BeginTransaction()
    {
        return Context.Database.BeginTransaction();
    }

    public void Save()
    {
        Context.SaveChanges();
    }

    public void Commit()
    {
        Save();
        if (Context.Database.CurrentTransaction != null)
            Context.Database.CurrentTransaction.Commit();
    }

    public void Rollback()
    {
        if (Context.Database.CurrentTransaction != null)
            Context.Database.CurrentTransaction.Rollback();
    }
}
