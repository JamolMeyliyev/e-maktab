
using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;


namespace e_maktab.DataLayer.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
}
