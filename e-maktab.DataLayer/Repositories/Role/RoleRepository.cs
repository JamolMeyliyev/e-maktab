
using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
    public override IQueryable<Role> SelectAll()
    {
        var entities = base.SelectAll();
        return entities.Include(s => s.State)
            .Include(s => s.RoleModules)
            .ThenInclude(s => s.Module).ThenInclude(s => s.State);
    }
    public override async ValueTask<Role?> SelectByIdAsync(int id)
    {
        return await this
            .SelectAll()
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}
