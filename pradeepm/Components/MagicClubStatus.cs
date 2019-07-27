using Microsoft.AspNetCore.Mvc;
using pradeepm.Models.DB;
using pradeepm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pradeepm.Components
{
    public class MagicClubStatus:ViewComponent
    {
        therisingstarContext _db;

        public MagicClubStatus(therisingstarContext context)
        {
            _db = context;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = HttpContext.Session.Get<LoginUser>("loginuser");
            //var mcstatus= await _db.Magicclub.Where(w => w.Accountid == user.loignid).ToAsyncEnumerable().FirstOrDefault();
            Magicclub mcstatus = null;
            ViewBag.requested = mcstatus == null ? false : true;
            ViewBag.approved = mcstatus != null && mcstatus.Status == 1 ? true : false;
            return View();
        }
    }
}
