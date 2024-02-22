using e_maktab.BizLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public class ClassService : IClassService
{
    public List<ClassAsSelectListDto> AsSelectList()
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(CreateClassDto dto)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public ClassDto Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<ClassDto> GetList(ClassListSortFilterOptions dto)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateClassDto dto)
    {
        throw new NotImplementedException();
    }
}
