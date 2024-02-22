using e_maktab.BizLogicLayer.Models.Atttendance;
using e_maktab.BizLogicLayer.Models.Science;

namespace e_maktab.BizLogicLayer.Services;

public interface IScienceService
{
    List<ScienceDto> GetList();
    List<ScienceAsSelectListDto> AsSelectList();
    Task<int> Create(CreateScienceDto dto);
    Task Update(UpdateScienceDto dto);
    Task Delete(int id);
}
