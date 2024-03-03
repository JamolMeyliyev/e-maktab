
using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
    public override IQueryable<User> SelectAll()
    {
        return base
            .SelectAll()
            .Include(s => s.Class)
            .Include(s => s.UserRoles)
            .ThenInclude(s => s.Role);
    }
    public override async ValueTask<User?> SelectByIdAsync(int id)
    {
        return await base
            .SelectAll()
            .Where(s => s.Id == id)
            .Include(s => s.Class)
            .Include(s => s.UserRoles)
            .ThenInclude(s => s.Role)
            .FirstOrDefaultAsync();
    }
}

