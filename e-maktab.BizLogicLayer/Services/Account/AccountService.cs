

using AutoMapper;
using e_maktab.BizLogicLayer.HelperServices.JwtToken;
using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Services.Account.Models;

using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using StatusGeneric;

namespace e_maktab.BizLogicLayer.Services;

public class AccountService : StatusGenericHandler, IAccountService
{
    private readonly ITokenService _tokenService;
    private readonly EMaktabContext _context;
    private readonly IMapper _mapper;
    public AccountService(ITokenService tokenService,EMaktabContext context,IMapper mapper)
    {
        _tokenService = tokenService;
        _context = context;
        _mapper = mapper;
    }
    public async Task<SuccessLoginDto> Login(LoginDto dto)
    {
        var user = await _context.Users.Include(s =>s.State).Include(s => s.UserRoles).ThenInclude(s => s.Role).FirstOrDefaultAsync(u => u.Login == dto.Login);
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
        
       var tokenModel = new SuccessLoginDto()
        {
            Token = token,
        };
        tokenModel.User = _mapper.Map<UserDto>(user);

        return tokenModel;
    }

    public Task LogOut()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsAuthenticated(LoginDto dto)
    {
        bool res = true;
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == dto.Login);
        if (user == null)
        {
            res = false;
            throw new Exception("UserName or Password is incorrect");
            
        }

        var result = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, dto.Password);

        if (result != PasswordVerificationResult.Success)
        {
            res = false;
            throw new Exception("UserName or Password is incorrect");
        }
        return res;
    }

    public User Register(CreateUserDto dto)
    {
        var entity = _mapper.Map<User>(dto);

        entity.PasswordHash = new PasswordHasher<User>().HashPassword(entity, dto.Password);

        return entity;

    }
}
