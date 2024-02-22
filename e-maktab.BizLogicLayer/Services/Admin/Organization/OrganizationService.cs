﻿using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
using WEBASE;
using WEBASE.Models;

namespace e_maktab.BizLogicLayer.Services.Admin;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _repos;
    private readonly IMapper _mapper;
    public OrganizationService(IOrganizationRepository repos, IMapper mapper)
    {
        _repos = repos;
        _mapper = mapper;
    }

    public List<OrganizationAsSelectListDto> AsSelectList()
    {
        throw new NotImplementedException();
    }

    public async Task<int> Create(CreateOrganizationDto dto)
    {
        var entity = _mapper.Map<Organization>(dto);
        var result = await _repos.InsertAsync(entity);
        return result.Id;

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public UserDto Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<OrganizationDto> GetList(OrganizationListSortFilterOptions dto)
    {
        var org = _repos.SelectAll().ToList();
        return _mapper.Map<List<OrganizationDto>>(org);
    }

    public void Update(UpdateOrganizationDto dto)
    {
        throw new NotImplementedException();
    }
}
