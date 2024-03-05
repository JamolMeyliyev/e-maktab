using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Services.Account.Models;
using e_maktab.DataLayer.Entities;
using StatusGeneric;

namespace e_maktab.BizLogicLayer.Services;

public interface IAccountService : IStatusGeneric
{
    User Register(CreateUserDto dto);
    Task<SuccessLoginDto> Login(LoginDto dto);
    Task LogOut();
    Task<bool> IsAuthenticated(LoginDto dto);
}
