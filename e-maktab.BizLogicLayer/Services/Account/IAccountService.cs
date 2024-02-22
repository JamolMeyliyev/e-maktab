using e_maktab.BizLogicLayer.Services.Account.Models;

using StatusGeneric;

namespace e_maktab.BizLogicLayer.Services;

public interface IAccountService : IStatusGeneric
{
    Task<SuccessLoginDto> Login(LoginDto dto);
    Task LogOut();
}
