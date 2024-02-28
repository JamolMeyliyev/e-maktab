

using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;

namespace e_maktab.DataLayer.Repositories;

public class ModuleRepository : GenericRepository<Module>, IModuleRepository
{
    public ModuleRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
}
