﻿
using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.HelperServices.JwtToken;

public interface ITokenService
{
    string GenerateToken(User user);    
}
