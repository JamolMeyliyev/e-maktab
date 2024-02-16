using e_maktab.BizLogicLayer.Service;
using e_maktab.DataLayer;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBASE.Models;

namespace e_maktab.BizLogicLayer.Services;

public interface IUserService : IStatusGeneric
{
    PagedResult<RoleListDto> GetList(RoleListSortFilterOptions dto);
    RoleDto Get(int id);
    public SelectList<int> AsSelectList(int? organizationId, int userTypeId);
    HaveId<int> Create(CreateRoleDto dto);
    void Update(UpdateRoleDto dto);
    void Delete(int id);
}
