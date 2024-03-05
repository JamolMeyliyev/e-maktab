using e_maktab.BizLogicLayer.Models;
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

public interface IUserService
{
    List<UserDto> GetList(UserListSortFilterOptions dto);
    Task<UserDto> Get(int id);
    public List<UserAsSelectListDto> AsSelectList();
    Task<int> Create(CreateUserDto dto);
    Task Update(UpdateUserDto dto);
    Task Delete(int id);
    
}
