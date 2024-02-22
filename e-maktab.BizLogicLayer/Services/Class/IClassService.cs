using e_maktab.BizLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public interface IClassService
{
    List<ClassDto> GetList(ClassListSortFilterOptions dto);
    ClassDto Get(int id);
    public List<ClassAsSelectListDto> AsSelectList();
    Task<int> Create(CreateClassDto dto);
    void Update(UpdateClassDto dto);
    void Delete(int id);
}
