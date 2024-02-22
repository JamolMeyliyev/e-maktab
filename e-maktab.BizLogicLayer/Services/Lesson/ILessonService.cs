using e_maktab.BizLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public interface ILessonService
{
    List<LessonDto> GetList(LessonListSortFilterOptions dto);
    Task<LessonDto> Get(int id);
    List<LessonAsSlectListDto> AsSelectList();
    Task<int> Create(CreateLessonDto dto);
    Task Update(UpdateLessonDto dto);
    Task Delete(int id);
}
