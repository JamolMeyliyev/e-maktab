using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Role;
using e_maktab.DataLayer;
using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBASE.Models;

namespace e_maktab.BizLogicLayer.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repos;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleModuleRepository _roleModuleRepos;
    public RoleService(IRoleRepository repos, IMapper mapper,IUnitOfWork unitOfWork, IRoleModuleRepository roleModuleRepos)
    {
        _repos = repos;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _roleModuleRepos = roleModuleRepos;
    }
    public List<RoleAsSelectListDto> AsSelectList()
    {
        return _repos.SelectAll().RoleSelectList();
    }

    public async Task<int> Create(CreateRoleDto dto)
    {
        var entity = _mapper.Map<Role>(dto);

       
        using (var transaction = _unitOfWork.BeginTransaction())
        {
            try
            {
               
                var role = await _repos.InsertAsync(entity);
                if (dto.Modules is not null && dto.Modules.Count > 0)
                {
                    foreach (var moduleId in dto.Modules)
                    {
                        var roleEntity = new RoleModule()
                        {
                            RoleId = role.Id,
                            ModuleId = moduleId
                            
                        };
                        await _roleModuleRepos.InsertAsync(roleEntity);

                    }
                }
                _unitOfWork.Commit();
                return role.Id;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception();
            }
        }
    }

    public async Task Delete(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        await _repos.DeleteAsync(entity);

    }

    public async Task<RoleDto> Get(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        return _mapper.Map<RoleDto>(entity);
    }

    public List<RoleDto> GetList(RoleListSortFilterOptions dto)
    {
        var list =  _repos.SelectAll().ToList();
        return _mapper.Map<List<RoleDto>>(list);
    }

    public async Task Update(UpdateRoleDto dto)
    {
        var entity = await _repos.SelectByIdAsync(dto.Id);
        await _repos.UpdateAsync(entity);
    }
}
