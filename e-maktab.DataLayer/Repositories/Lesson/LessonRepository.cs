using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.DataLayer.Repositories;

public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
{
    
    public LessonRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
    public override IQueryable<Lesson> SelectAll()
    {
        var entities = base.SelectAll();
        return
             entities
            
            .Include(s => s.Homeworks).ThenInclude(s => s.Teacher)
            .Include(s => s.Teacher)
            .Include(s => s.Science)
            .Include(s => s.State);
    }
    public override async ValueTask<Lesson?> SelectByIdAsync(int id)
    {
        return await this.SelectAll().FirstOrDefaultAsync(x => x.Id == id);
    }

}
