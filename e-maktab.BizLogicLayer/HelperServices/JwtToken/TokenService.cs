using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.HelperServices.JwtToken;

public class TokenService : ITokenService
{
    private readonly JwtOptions _jwtOption;
    private readonly IModuleRepository _moduleRepos;
    public TokenService(IOptions<JwtOptions> jwtOption,IModuleRepository moduleRepository)
    {
        _jwtOption = jwtOption.Value;
        _moduleRepos = moduleRepository;
    }
    
    public string GenerateToken(User user)
    {
        var roles = user.UserRoles.Select(s => s.Role).ToList();
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            
               
        };

        foreach(var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.FullName.ToString()));
        }
        
        var signingKey = System.Text.Encoding.UTF32.GetBytes(_jwtOption.SigningKey);
        var security = new JwtSecurityToken(
            issuer: _jwtOption.ValidIssuer,
            audience: _jwtOption.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtOption.ExpiresInMinutes),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256)
        );

        var token = new JwtSecurityTokenHandler().WriteToken(security);

        return token;
    }
}
