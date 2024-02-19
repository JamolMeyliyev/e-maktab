using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;

namespace e_maktab.DataLayer.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
}
