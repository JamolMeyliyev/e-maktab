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
    PagedResult<UserListDto> GetList(UserListSortFilterOptions dto);
    UserDto Get(int id);
    public SelectList<int> AsSelectList();
    Task<HaveId<int>> Create(CreateUserDto dto);
    void Update(UpdateUserDto dto);
    void Delete(int id);
}
