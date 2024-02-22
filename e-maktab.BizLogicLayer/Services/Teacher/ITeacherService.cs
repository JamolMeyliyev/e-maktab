using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Science;
using e_maktab.BizLogicLayer.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public interface ITeacherService
{
    List<TeacherDto> GetList(TeacherListSortFilterOptions options);
    List<TeacherAsSelectListDto> AsSelectList();
    Task<int> Create(CreateTeacherDto dto);
    Task Update(UpdateTeacherDto dto);
    Task Delete(int id);
}
