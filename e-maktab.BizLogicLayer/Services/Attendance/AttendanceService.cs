using AutoMapper;
using e_maktab.BizLogicLayer.Models.Atttendance;
using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _repos;
    private readonly IMapper _mapper;
    public AttendanceService(IAttendanceRepository repos,IMapper mapper)
    {
        _repos = repos;
        _mapper = mapper;
    }
    public List<AttendanceAsSelectListDto> AsSelectList()
    {
        return _repos.SelectAll().AttendanceSelectList();
    }

    public async Task<int> Create(CreateAttendanceDto attendance)
    {
        var entity = _mapper.Map<Attendance>(attendance);
        var result  = await _repos.InsertAsync(entity);
        return result.Id;
    }

    public async Task Delete(int id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        await _repos.DeleteAsync(entity);
    }

    public List<AttendanceDto> GetList()
    {
        var entities =  _repos.SelectAll().ToList();
        return _mapper.Map<List<AttendanceDto>>(entities);
    }


    
}
