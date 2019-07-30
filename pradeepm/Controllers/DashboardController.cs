using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pradeepm.Models.DB;

namespace pradeepm.Controllers
{
    public class DashboardController : Controller
    {
        private therisingstarContext _db;

        public DashboardController(therisingstarContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {

            var binarydetails = _db.Userbinaries.FromSql($"sp_userbinarydetails {ModelGloble.loginuser.loignid}").AsEnumerable();
            ViewBag.leftcount = 0;
            ViewBag.rightcount = 0;
            ViewBag.directcount = 0;
            if(binarydetails.Where(w=>w.Legno==1).Count()>0)
                ViewBag.leftcount = binarydetails.Where(w => w.Legno == 1).Select(s => s.Count).FirstOrDefault();
            if (binarydetails.Where(w => w.Legno == 2).Count() > 0)
                ViewBag.rightcount = binarydetails.Where(w => w.Legno == 1).Select(s => s.Count).FirstOrDefault();
            if (binarydetails.Where(w => w.Legno == 3).Count() > 0)
                ViewBag.directcount = binarydetails.Where(w => w.Legno == 1).Select(s => s.Count).FirstOrDefault();
            
            return View();
        }
    }
}