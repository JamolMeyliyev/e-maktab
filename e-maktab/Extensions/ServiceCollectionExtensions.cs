using e_maktab.BizLogicLayer.HelperServices.JwtToken;
using e_maktab.BizLogicLayer.Services;
using e_maktab.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using e_maktab.DataLayer;
using e_maktab.BizLogicLayer.Services.Admin.Organization.Mapper;

namespace e_maktab.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleModuleRepository, RoleModuleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddAutoMapper(typeof(OrganizationMapper));

        return services;
    }
}

