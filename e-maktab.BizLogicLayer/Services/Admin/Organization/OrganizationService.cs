using AutoMapper;
using e_maktab.BizLogicLayer.Models.Organization;
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
       return _repos.SelectAll().TeacherSelectList();
    }

    public async Task<int> Create(CreateOrganizationDto dto)
    {
        var entity = _mapper.Map<Organization>(dto);
        var result = await _repos.InsertAsync(entity);
        return result.Id;

    }

    public async Task Delete(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        await _repos.DeleteAsync(entity);
    }

    public async Task<OrganizationDto> Get(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        return _mapper.Map<OrganizationDto>(entity);
    }

    public List<OrganizationDto> GetList(OrganizationListSortFilterOptions dto)
    {
        var org = _repos.SelectAll().ToList();
        return _mapper.Map<List<OrganizationDto>>(org);
    }

    public async Task Update(UpdateOrganizationDto dto)
    {
        var entity = await _repos.SelectByIdAsync(dto.Id);
        await _repos.UpdateAsync(entity);
    }
}
