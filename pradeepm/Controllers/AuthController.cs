using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pradeepm.Models;
using pradeepm.Models.DB;

namespace pradeepm.Controllers
{
    public class AuthController : Controller
    {
        therisingstarContext _db;
        public AuthController(therisingstarContext context) => _db = context;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _db.AccountUsers.Where(w => w.AccountId.ToLower() == model.userid.ToLower()).FirstOrDefault();
                if (user.Password != null && user.Password == model.password)
                {


                    HttpContext.Session.Set("loginuser", new LoginUser
                    {
                        loignid = user.Id,

                        username = user.DisplayName,
                        usertype = user.AccountId.ToLower() == "admin" ? "admin" : "user"
                    });

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("form", "User id or password is wrong");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            
            return RedirectToAction("Login");
        }
    }
}