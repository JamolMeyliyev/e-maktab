
using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;


namespace e_maktab.DataLayer.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
}
