using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public interface IClassService
{
    List<ClassDto> GetList(ClassListSortFilterOptions dto);
    Task<ClassDto> Get(int id);
    public List<ClassAsSelectListDto> AsSelectList();
    Task<int> Create(CreateClassDto dto);
    Task Update(UpdateClassDto dto);
    Task Delete(int id);
    Task<int> AddUser(int classId, int userId);
}
