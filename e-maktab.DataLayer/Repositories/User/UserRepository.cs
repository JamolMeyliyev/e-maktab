
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
        var entities = base.SelectAll();
        return entities
            .Include(s => s.Class)
            .Include(s => s.UserRoles)
            .ThenInclude(s => s.Role).ThenInclude(s => s.State)
            .Include(s => s.State);
    }
    public override async ValueTask<User?> SelectByIdAsync(int id)
    {
        return await this
            .SelectAll()
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}

