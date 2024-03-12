using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Services;
using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
using Microsoft.AspNetCore.Identity;

namespace e_maktab.BizLogicLayer.Service;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repos;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepos;
    public TeacherService(ITeacherRepository repos, IMapper mapper, IUserRepository userRepos)
    {
        _repos = repos;
        _mapper = mapper;
        _userRepos = userRepos;
    }
    public List<TeacherAsSelectListDto> AsSelectList()
    {
       return _repos.SelectAll().TeacherSelectList();
    }

    public async Task<int> Create(CreateTeacherDto dto)
    {
        var entity = _mapper.Map<Teacher>(dto);
        var user = new User()
        {
            FirstName= entity.FirstName,
            LastName= entity.LastName,
            Email= entity.Email,
            DateOfCreated= entity.DateOfCreated,
            PhoneNumber= entity.PhoneNumber,
            OrganizationId = entity.OrganizationId,
            StateId=entity.StateId,
            Login = dto.Login,
            IsTeacher = true
            
        };

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, user.Login );
        
        await _userRepos.InsertAsync( user );
        var result = await _repos.InsertAsync(entity);
        return result.Id;
    }

    public async Task Delete(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        await _repos.DeleteAsync(entity);
    }

    public async Task<TeacherDto> Get(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        return _mapper.Map<TeacherDto>(entity);
    }

    public List<TeacherDto> GetList(TeacherListSortFilterOptions options)
    {
        var list = _repos.SelectAll().ToList();
        return _mapper.Map<List<TeacherDto>>(list);
    }

    public async Task Update(UpdateTeacherDto dto)
    {
        var entity = await _repos.SelectByIdAsync(dto.Id);
        await _repos.UpdateAsync(entity);
    }
}
