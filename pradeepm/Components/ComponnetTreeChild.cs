using Microsoft.AspNetCore.Mvc;
using pradeepm.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pradeepm.Components
{
    public class TreeChild:ViewComponent
    {
        therisingstarContext _db;

        public TreeChild(therisingstarContext context)
        {
            _db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int upperid,int level)
        {
            var childuserlist = _db.AccountUsers.Where(w => w.FatherId == upperid).ToList();
            ViewBag.level = level;
            return View(childuserlist);
        }
    }
}
