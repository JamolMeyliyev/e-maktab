﻿using e_maktab.DataLayer.Context;
using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.DataLayer.Repositories;

public class ScienceRepository : GenericRepository<Science>, IScienceRepository
{
    public ScienceRepository(EMaktabContext appDbContext) : base(appDbContext)
    {
    }
}
