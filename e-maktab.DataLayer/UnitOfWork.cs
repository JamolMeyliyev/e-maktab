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
    private readonly EMaktabContext context;
    public UnitOfWork(IServiceProvider serviceProvider,
        EMaktabContext context)
    {
        _serviceProvider = serviceProvider;
        this.context = context;
    }

    public void Commit()
    {
        if (context.Database.CurrentTransaction != null)
        {
            context.Database.CurrentTransaction.Commit();
        }
    }

    public void Rollback()
    {
        if (context.Database.CurrentTransaction != null)
        {
            context.Database.CurrentTransaction.Rollback();
        }
    }

    public IDbContextTransaction BeginTransaction()
    {
        return context.Database.BeginTransaction();
    }

    public IDbContextTransaction CurrencyTransaction => context.Database.CurrentTransaction;
}