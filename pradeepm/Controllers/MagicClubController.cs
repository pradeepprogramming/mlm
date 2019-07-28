using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pradeepm.Models;
using pradeepm.Models.DB;

namespace pradeepm.Controllers
{
    public class MagicClubController : Controller
    {
        therisingstarContext _db;
        public MagicClubController(therisingstarContext context) => _db = context;

        public IActionResult Index()
        {
            List<ModelMagicClub> list = (from m in _db.Magicclub
                                         join a in _db.AccountUsers on m.Accountid equals a.Id
                                         join p in _db.PrasnalDetails on m.Accountid equals p.AccountUserId
                                    select new ModelMagicClub
                                    {
                                        Accountid = m.Accountid,
                                        AccountName = a.DisplayName,
                                        Id = m.Id,
                                        Joiningdate = m.Joiningdate,
                                        ProfilePic = p.Profilepic,
                                        Requestdate = m.Requestdate,
                                        Status = m.Status,
                                        UserID=a.AccountId

                                    }).ToList();
            return View(list);
        }

        public IActionResult Approve(int id)
        {
            if (id > 0)
            {
                var request = _db.Magicclub.Where(w => w.Id == id).FirstOrDefault();
                if (request != null)
                {
                    request.Joiningdate = DateTime.Now;
                    request.Status = 1;

                    if (_db.SaveChanges() > 0)
                    {
                        return Ok("success");
                    }
                }
            }
            return NotFound("Faild");

        }

        public IActionResult AddtoClub()
        {
            var user = HttpContext.Session.Get<LoginUser>("loginuser");
            if (_db.Magicclub.Where(w => w.Accountid == user.loignid).Count() > 0)
            {
                HttpContext.Session.SetAlert(new Alertmessage { Type = Alerttype.error, Message = "you are already requested for Magic Club" });
            }
            else
            {
                _db.Magicclub.Add(new Magicclub
                {
                    Accountid = user.loignid,
                    Requestdate = DateTime.Now,
                    Joiningdate = null,
                    Status = 0
                });
                if (_db.SaveChanges() > 0)
                {
                    HttpContext.Session.SetAlert(new Alertmessage { Type = Alerttype.success, Message = "Your Request is proccessed, Plz Make payment for that" });
                }
                else
                {
                    HttpContext.Session.SetAlert(new Alertmessage { Type = Alerttype.warning, Message = "Your Request is not proccessed, Plz try after some time" });
                }
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}