using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using pradeepm.Controllers;
using pradeepm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pradeepm.Filters
{
    public class OAuthFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var loginuser = context.HttpContext.Session.Get<LoginUser>("loginuser");
            ModelGloble.loginuser = loginuser;
            if (context.Controller.GetType() != typeof(AuthController) && loginuser == null)
            {
                context.Result = new RedirectResult("/Auth/Login");
                return;
            }
        }
    }
}
