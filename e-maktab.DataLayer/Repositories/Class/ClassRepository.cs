using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.DataLayer.Repositories;

public class ClassRepository : GenericRepository<Class>, IClassRepository
{
    private readonly EMaktabContext _context;
    public ClassRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
        _context = appDbContext;
    }
    public override IQueryable<Class> SelectAll()
    {
        
            
        var entities = base.SelectAll();

        entities = entities
            .Include(s => s.Teacher)
            .Include(s => s.Lessons)
            .ThenInclude(s => s.Science)
            .Include(s => s.Users)
            .Include(s => s.State); 

        return entities;
    }
    public override  async ValueTask<Class?> SelectByIdAsync(int id)
    {
       return await this.SelectAll().FirstOrDefaultAsync(x => x.Id == id);
    }

}
