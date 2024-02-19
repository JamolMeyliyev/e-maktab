using e_maktab.Core.Options;
using Microsoft.AspNetCore.Mvc;

namespace e_maktab.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorizeAttribute : TypeFilterAttribute
{
    public AuthorizeAttribute()
        : base(typeof(AuthorizeFilter))
    {
        Arguments = new[] { new string[] { } };
    }

    public AuthorizeAttribute(params ModuleCode[] moduleCodes)
        : base(typeof(AuthorizeFilter))
    {
        Arguments = new[] { moduleCodes.Select(c => c.ToString()).ToArray() };
    }
}
