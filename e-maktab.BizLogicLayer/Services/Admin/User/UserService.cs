using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer;

using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
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

    public UserService(
        IMapper mapper,
        IUserRepository repos, 
        IUnitOfWork unitOfWork,
        IRoleService roleService, 
        IUserRoleRepository userRoleRepos,
        ITeacherRepository teacherRepository)
    {
        _mapper = mapper;
        _repos = repos;
        _unitOfWork = unitOfWork;
        _roleService = roleService;
        _userRoleRepos = userRoleRepos;
        _teacherRepos = teacherRepository;
    }

    public List<UserAsSelectListDto> AsSelectList()
    {
        return _repos.SelectAll().UserSelectList();
    }

    public async Task<int> Create(CreateUserDto dto)
    {
        var entity = _mapper.Map<User>(dto);
        using (var transaction = _unitOfWork.BeginTransaction())
        {
            try
            {
                if(dto.IsTeacher)
                {
                    var teacher = _mapper.Map<Teacher>(dto);
                    var result = await _teacherRepos.InsertAsync(teacher);
                    await transaction.CommitAsync();                   
                }
                var user = await _repos.InsertAsync(entity);
                if (dto.Roles is not null && dto.Roles.Count > 0)
                {
                    foreach (var roleId in dto.Roles)
                    {
                        var roleEntity = new UserRole()
                        {
                            RoleId = roleId,
                            UserId = user.Id,
                            StateId = 1,
                            DateOfCreated = DateTime.UtcNow,
                        };
                        await _userRoleRepos.InsertAsync(roleEntity);

                    }
                }
                await transaction.CommitAsync();
                return user.Id;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception();
            }
        }

    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public UserDto Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<UserDto> GetList(UserListSortFilterOptions dto)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }
}
