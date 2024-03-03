using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Atttendance;


namespace e_maktab.BizLogicLayer.Services;

public interface IAttendanceService
{
    List<AttendanceDto> GetList(AttendanceListSortFilterOptions options);
    List<AttendanceAsSelectListDto> AsSelectList();
    Task<int> Create(CreateAttendanceDto attendance);
    Task Delete(int id);
}
