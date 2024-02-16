using e_maktab.BizLogicLayer.Service;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBASE.Models;

namespace e_maktab.BizLogicLayer.Services;

public class UserService : StatusGenericHandler, IUserService
{
    public SelectList<int> AsSelectList(int? organizationId, int userTypeId)
    {
        throw new NotImplementedException();
    }

    public HaveId<int> Create(CreateRoleDto dto)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public RoleDto Get(int id)
    {
        throw new NotImplementedException();
    }

    public PagedResult<RoleListDto> GetList(RoleListSortFilterOptions dto)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateRoleDto dto)
    {
        throw new NotImplementedException();
    }
}
