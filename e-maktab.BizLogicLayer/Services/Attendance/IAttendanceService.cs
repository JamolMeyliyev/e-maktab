using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Atttendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public interface IAttendanceService
{
    List<AttendanceDto> GetList();
    List<AttendanceAsSelectListDto> AsSelectList();
    Task<int> Create(CreateAttendanceDto attendance);
    Task Delete(int id);
}
