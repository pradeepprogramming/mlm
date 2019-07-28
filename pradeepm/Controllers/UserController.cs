using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pradeepm.Models;
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
        public IActionResult GetUserName(string accountid)
        {
            var user = _db.AccountUsers.Where(w=>w.AccountId== accountid).FirstOrDefault();
            if(user!=null && user.DisplayName.Length>0)
            {
                return Ok(user.DisplayName);
            }
            return Ok("ID not correct");
        }
        public IActionResult GetSides(string accountid)
        {
            string returnstring = "0";
            var rootid=_db.AccountUsers.Where(w => w.AccountId == accountid).Select(s => s.Id).FirstOrDefault();
            var childs = _db.AccountUsers.Where(w => w.FatherId == rootid).AsEnumerable();
            if (childs.Where(w => w.Side == 1).Count() == 0)
                returnstring += "1";
            if (childs.Where(w => w.Side == 2).Count() == 0)
                returnstring += "2";
            return Ok(returnstring);
        }
        public IActionResult Join(string pincode)
        {
            var cuser = HttpContext.Session.Get<LoginUser>("loginuser");
            return View(new ModelUserJoin() {Pincode=pincode,Sponserid=_db.AccountUsers.Where(w=>w.Id==cuser.loignid).Select(s=>s.AccountId).FirstOrDefault()});
        }
        [HttpPost]
        public IActionResult Join(ModelUserJoin model)
        {
            if(ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}