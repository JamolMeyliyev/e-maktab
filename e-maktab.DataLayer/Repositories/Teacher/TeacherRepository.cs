using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
    public override IQueryable<Teacher> SelectAll()
    {
        var entities = base.SelectAll();
        return entities
            .Include(s => s.Classes)
            .Include(s => s.Homeworks)
            .Include(s => s.Lessons)
            .Include(s => s.State);
    }
    public override async ValueTask<Teacher?> SelectByIdAsync(int id)
    {
        return await this
            .SelectAll()
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}