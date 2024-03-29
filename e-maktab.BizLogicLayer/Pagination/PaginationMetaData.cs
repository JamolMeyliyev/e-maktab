﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Pagination;

public class PaginationMetaData
{
    public PaginationMetaData(int totalCount, int pageSize, int pageNumber)
    {
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    }

    public int CurrentPage { get; }
    public int TotalCount { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}
