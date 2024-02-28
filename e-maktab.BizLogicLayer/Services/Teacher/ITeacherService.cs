using e_maktab.BizLogicLayer.Models;



namespace e_maktab.BizLogicLayer.Services;

public interface ITeacherService
{
    List<TeacherDto> GetList(TeacherListSortFilterOptions options);
    Task<TeacherDto> Get(int id);
    List<TeacherAsSelectListDto> AsSelectList();
    Task<int> Create(CreateTeacherDto dto);
    Task Update(UpdateTeacherDto dto);
    Task Delete(int id);
}
