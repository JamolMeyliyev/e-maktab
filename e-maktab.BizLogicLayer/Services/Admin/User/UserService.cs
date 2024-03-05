using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer;

using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using StatusGeneric;
using WEBASE.Models;

namespace e_maktab.BizLogicLayer.Services;

public class UserService :  IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _repos;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleService _roleService;
    private readonly IUserRoleRepository _userRoleRepos;
    private readonly ITeacherRepository _teacherRepos;
    private readonly IAccountService _accService;

    public UserService(
        IMapper mapper,
        IUserRepository repos, 
        IUnitOfWork unitOfWork,
        IRoleService roleService, 
        IUserRoleRepository userRoleRepos,
        ITeacherRepository teacherRepository,
        IAccountService accService)
    {
        _mapper = mapper;
        _repos = repos;
        _unitOfWork = unitOfWork;
        _roleService = roleService;
        _userRoleRepos = userRoleRepos;
        _teacherRepos = teacherRepository;
        _accService = accService;
    }

    public List<UserAsSelectListDto> AsSelectList()
    {
        return _repos.SelectAll().UserSelectList();
    }

    public async Task<int> Create(CreateUserDto dto)
    {

        var userEntity = _accService.Register(dto);

        using (var transaction = _unitOfWork.BeginTransaction())
        {
            try
            {
                if(dto.IsTeacher)
                {
                    var teacher = _mapper.Map<Teacher>(dto);
                    var result = await _teacherRepos.InsertAsync(teacher);
                                       
                }
                var user = await _repos.InsertAsync(userEntity);

                if (dto.Roles is not null && dto.Roles.Count > 0)
                {
                    foreach (var roleId in dto.Roles)
                    {
                        var roleEntity = new UserRole()
                        {
                            RoleId = roleId,
                            UserId = user.Id,
                            StateId = 1
                            
                        };
                        await _userRoleRepos.InsertAsync(roleEntity);

                    }
                }
                await _unitOfWork.CurrencyTransaction.CommitAsync();
                return user.Id;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception();
            }
        }

    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> Get(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        return _mapper.Map<UserDto>(entity);
    }

    public List<UserDto> GetList(UserListSortFilterOptions dto)
    {
        var list = _repos.SelectAll().ToList();
        return _mapper.Map<List<UserDto>>(list);
    }

    public async Task<bool> IsAuthenticated(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        return entity != null;
    }

    public Task Update(UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }
}
