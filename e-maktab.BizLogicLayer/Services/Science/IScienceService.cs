using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Atttendance;
using e_maktab.BizLogicLayer.Models.Science;

namespace e_maktab.BizLogicLayer.Services;

public interface IScienceService
{
    List<ScienceDto> GetList(ScienceListSortFilterOptions options);
    Task<ScienceDto> Get(int id);
    List<ScienceAsSelectListDto> AsSelectList();
    Task<int> Create(CreateScienceDto dto);
    Task Update(UpdateScienceDto dto);
    Task Delete(int id);
}
