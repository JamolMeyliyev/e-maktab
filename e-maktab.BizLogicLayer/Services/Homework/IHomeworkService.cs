using e_maktab.BizLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public interface IHomeworkService
{
    List<HomeworkDto> GetList(HomeworkListSortFilterOptions options);
    Task<HomeworkDto> Get(int id);
    public List<HomeworkAsSelectListDto> AsSelectList();
    Task<int> Create(CreateHomeworkDto dto);
    Task Update(UpdateHomeworkDto dto);
    Task Delete(int id);
}
