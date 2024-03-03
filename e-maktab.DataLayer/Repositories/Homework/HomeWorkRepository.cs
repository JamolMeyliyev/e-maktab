using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Repositories;

public class HomeWorkRepository : GenericRepository<Homework>, IHomeWorkRepository
{
    public HomeWorkRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
    public override IQueryable<Homework> SelectAll()
    {
        var entities = base.SelectAll();
        return entities
            .Include(s => s.Teacher)
            .Include(s => s.Lesson)
            .Include(s => s.State);
    }
    public override async ValueTask<Homework?> SelectByIdAsync(int id)
    {
        return await this
            .SelectAll()
            .Where(s => s.Id == id)
            .Include(s => s.Teacher)
            .Include(s => s.Lesson)
            .Include( s => s.State)
            .FirstOrDefaultAsync();
    }
}
