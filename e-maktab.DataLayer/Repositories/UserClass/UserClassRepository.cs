using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.DataLayer.Repositories;

public class UserClassRepository : GenericRepository<UserClass>, IUserClassRepository
{
    public UserClassRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
    public override IQueryable<UserClass> SelectAll()
    {
        var entities = base.SelectAll();
        entities = entities.Include(s => s.User).Include(s => s.Class);
        return entities;
    }
}
