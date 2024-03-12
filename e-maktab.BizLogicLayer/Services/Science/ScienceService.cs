using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Science;
using e_maktab.BizLogicLayer.Services;
using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public class ScienceService : IScienceService
{
    private readonly IScienceRepository _repos;
    private readonly IMapper _mapper;
    public ScienceService(IScienceRepository repos, IMapper mapper)
    {
        _repos = repos;
        _mapper = mapper;
    }
    public List<ScienceAsSelectListDto> AsSelectList()
    {
        return _repos.SelectAll().ScienceSelectList();
    }

    public async Task<int> Create(CreateScienceDto dto)
    {
        var entity = _mapper.Map<Science>(dto);
        var result = await _repos.InsertAsync(entity);
        return result.Id;
    }

    public async Task Delete(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        await _repos.DeleteAsync(entity);
    }

    public async Task<ScienceDto> Get(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        return _mapper.Map<ScienceDto>(entity);
    }

    public List<ScienceDto> GetList(ScienceListSortFilterOptions options)
    {
        var list = _repos.SelectAll().ToList();
        return _mapper.Map<List<ScienceDto>>(list);
    }

    public async Task Update(UpdateScienceDto dto)
    {
        var entity = await _repos.SelectByIdAsync(dto.Id);
        await _repos.UpdateAsync(entity);
    }
}
