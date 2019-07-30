using Microsoft.AspNetCore.Mvc;
using pradeepm.Models;
using pradeepm.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pradeepm.Components
{
    public class LastFiveJoin:ViewComponent
    {
        therisingstarContext _db;

        public LastFiveJoin(therisingstarContext context)
        {
            _db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var lastfivejoin =  (from t in _db.TreeRelation
                                join a in _db.AccountUsers on t.Accountid equals a.Id
                                where t.Upperid==ModelGloble.loginuser.loignid 
                                orderby t.Mlevel descending
                                select new ModelLastFiveUser {
                                    AccountId= a.AccountId,
                                    DisplayName=a.DisplayName,
                                    ProfilePic=a.PrasnalDetails.FirstOrDefault().Profilepic
                                }).Take(5).AsEnumerable();
            ViewBag.lastfive = lastfivejoin;
            return View();
        }
    }
}
