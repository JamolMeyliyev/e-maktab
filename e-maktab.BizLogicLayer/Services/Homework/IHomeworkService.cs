using e_maktab.BizLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public interface IHomeworkService
{
    List<OrganizationDto> GetList(OrganizationListSortFilterOptions dto);
    UserDto Get(int id);
    public List<OrganizationAsSelectListDto> AsSelectList();
    Task<int> Create(CreateOrganizationDto dto);
    void Update(UpdateOrganizationDto dto);
    void Delete(int id);
}
