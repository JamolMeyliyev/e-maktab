using e_maktab.DataLayer.Entities;
using Microsoft.Extensions.Logging;


namespace e_maktab.DataLayer.Repositories;

public interface IModuleRepository:IGenericRepository<Module>
{
    Module[] GetAllForUser(string login);
}
