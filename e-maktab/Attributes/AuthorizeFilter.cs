using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using WEBASE.Security;
using WEBASE.AspNet.Security;

namespace e_maktab.Attributes;

//public class AuthorizeFilter : Attribute
//{
//    protected string[] ModuleCodes { get; }

//    public AuthorizeFilter(string[] moduleCodes)
//    {
//        ModuleCodes = moduleCodes;
//    }

//    public virtual void OnAuthorization(AuthorizationFilterContext context)
//    {
//        if (!context.Filters.Any((IFilterMetadata a) => a is AllowAnonymousAttribute))
//        {
           
//            if ((ModuleCodes?.Any()).GetValueOrDefault() && !ModuleCodes.Any((string moduleCode) => authService.HasPermission(moduleCode)))
//            {
//                context.Result = new StatusCodeResult(403);
//            }
//        }
//    }
//}
