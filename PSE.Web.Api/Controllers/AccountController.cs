using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSE.Web.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController:Controller
    {
        [HttpGet]
        public IActionResult LoginCallback()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return Unauthorized();
        }

        //Google API does not have signout endpoint!
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");

            return Ok();
        }

    }
}
