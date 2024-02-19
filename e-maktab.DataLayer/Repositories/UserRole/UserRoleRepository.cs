﻿using e_maktab.DataLayer.AutoGenerated;
using e_maktab.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.DataLayer.Repositories;

public class UserRoleRepository : GenericRepository<UserRole>,IUserRoleRepository
{
    public UserRoleRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
}
