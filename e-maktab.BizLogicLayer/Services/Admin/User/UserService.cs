using AutoMapper;

using e_maktab.DataLayer;

using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
using StatusGeneric;
using WEBASE.Models;

namespace e_maktab.BizLogicLayer.Services;

public class UserService : StatusGenericHandler, IUserService
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

    public SelectList<int> AsSelectList()
    {
        throw new NotImplementedException();
    }

    public async Task<HaveId<int>> Create(CreateUserDto dto)
    {
        var entity = _mapper.Map<User>(dto);
        using (var transaction = _unitOfWork.BeginTransaction())
        {
            try
            {
                if(dto.IsTeacher)
                {
                    var teacher = _mapper.Map<Teacher>(dto);
                    await _teacherRepos.InsertAsync(teacher);
                    await transaction.CommitAsync();
                    return HaveId.Create(teacher.Id);
                    
                }
                else
                {
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
                            //await _userRoleRepos.InsertAsync(roleEntity);

                        }
                    }
                    await transaction.CommitAsync();
                    return HaveId.Create(user.Id);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception();
            }
        }

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public UserDto Get(int id)
    {
        throw new NotImplementedException();
    }

    public PagedResult<UserListDto> GetList(UserListSortFilterOptions dto)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }
}
