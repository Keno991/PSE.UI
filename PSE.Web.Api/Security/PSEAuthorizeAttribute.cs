using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PSE.Web.Api.Security
{
    public class PSEAuthorizeAttribute:AuthorizeFilter
    {
        public PSEAuthorizeAttribute(AuthorizationPolicy policy) : base(policy)
        {

        }

        public override Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            return base.OnAuthorizationAsync(context);
        }
    }
}
