

using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Repositories;

public class ModuleRepository : GenericRepository<Module>, IModuleRepository
{
    private readonly EMaktabContext _context;
    public ModuleRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
        _context = appDbContext;
    }

    public Module[] GetAllForUser(string login)
    {
       return _context.Modules
            .Include(s => s.RoleModules)
            .ThenInclude(s => s.Role)
            .ThenInclude(s => s.UserRoles)
            .ThenInclude(s => s.User.Login == login)
            .ToArray();
       
    }
}
