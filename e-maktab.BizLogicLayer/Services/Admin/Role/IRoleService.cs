using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Role;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBASE.Models;

namespace e_maktab.BizLogicLayer.Services;

public interface IRoleService 
{
    List<RoleDto> GetList(RoleListSortFilterOptions dto);
    Task<RoleDto> Get(int id);
    public List<RoleAsSelectListDto> AsSelectList();
    Task<int> Create(CreateRoleDto dto);
    Task Update(UpdateRoleDto dto);
    Task Delete(int id);
}
