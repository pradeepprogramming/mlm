using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pradeepm.Models.DB;

namespace pradeepm.Controllers
{
    public class UserController : Controller
    {
        therisingstarContext _db;
        public UserController(therisingstarContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var users = _db.AccountUsers.AsEnumerable();
            return View(users);
        }
    }
}