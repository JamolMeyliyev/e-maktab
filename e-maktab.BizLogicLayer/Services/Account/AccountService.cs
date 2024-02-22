

using e_maktab.BizLogicLayer.HelperServices.JwtToken;
using e_maktab.BizLogicLayer.Services.Account.Models;

using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StatusGeneric;

namespace e_maktab.BizLogicLayer.Services;

public class AccountService : StatusGenericHandler, IAccountService
{
    private readonly ITokenService _tokenService;
    private readonly EMaktabContext _context;
    public AccountService(ITokenService tokenService,EMaktabContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }
    public async Task<SuccessLoginDto> Login(LoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.FirstName == dto.UserName);
        if (user == null)
        {
            throw new Exception("UserName or Password is incorrect");
        }

        var result = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, dto.Password);

        if (result != PasswordVerificationResult.Success)
        {
            throw new Exception("UserName or Password is incorrect");
        }

        var token = _tokenService.GenerateToken(user);
        
        return new SuccessLoginDto()
        {
            Token = token
        };
       
    }

    public Task LogOut()
    {
        throw new NotImplementedException();
    }
}
