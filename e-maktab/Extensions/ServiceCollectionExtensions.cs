using e_maktab.BizLogicLayer.HelperServices.JwtToken;
using e_maktab.BizLogicLayer.Services;
using e_maktab.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using e_maktab.DataLayer;
using e_maktab.BizLogicLayer.Services.Admin.Organization.Mapper;
using e_maktab.BizLogicLayer.Services.Admin;
using e_maktab.BizLogicLayer.Service;

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
        services.AddScoped<IScienceService, ScienceService>();
        services.AddScoped<IHomeworkService, HomeworkService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<IOrganizationService,OrganizationService>();
        services.AddScoped<ITeacherService, TeacherService>();

        //services.AddAutoMapper(typeof(UserMapper));

        return services;
    }
}

