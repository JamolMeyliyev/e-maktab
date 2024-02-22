﻿using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.DataLayer.Repositories;

public class RoleModuleRepository : GenericRepository<RoleModule>,IRoleModuleRepository

{
    public RoleModuleRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
}
