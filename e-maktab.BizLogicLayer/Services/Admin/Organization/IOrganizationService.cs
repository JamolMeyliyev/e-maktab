using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_maktab.BizLogicLayer.Models;
using WEBASE.Models;

namespace e_maktab.BizLogicLayer.Services.Admin;

public interface IOrganizationService
{
    List<OrganizationDto> GetList(OrganizationListSortFilterOptions dto);
    UserDto Get(int id);
    public List<OrganizationAsSelectListDto> AsSelectList();
    Task<int> Create(CreateOrganizationDto dto);
    void Update(UpdateOrganizationDto dto);
    void Delete(int id);
}
