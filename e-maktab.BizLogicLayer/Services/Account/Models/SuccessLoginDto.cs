using e_maktab.BizLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services.Account.Models;

public class SuccessLoginDto
{
    public string Token { get; set; }
    public UserDto User { get; set; }
}
