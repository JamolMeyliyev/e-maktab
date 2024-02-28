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
       return base.SelectAll().Include(s => s.Class).Include(s => s.Science);
    }
       

}
