using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Pagination;



public static class CustomPagedList
{
    public static IEnumerable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams? pageParams)
    {
        pageParams ??= new PaginationParams();

        HttpContextHelper.AddResponseHeader("X-Pagination",
            JsonSerializer.Serialize(new PaginationMetaData(source.Count(), pageParams.Size, pageParams.Page)));

        return source.Skip(pageParams.Size * (pageParams.Page - 1)).Take(pageParams.Size).ToList();
    }
}
