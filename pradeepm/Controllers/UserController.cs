using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pradeepm.Models;
using pradeepm.Models.BL;
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
            var users = (from a in _db.AccountUsers
                         join ad in _db.AccountUsers on a.SponserId equals ad.Id
                         join af in _db.AccountUsers on a.FatherId equals af.Id
                         select new
                         {
                             UserAccount = a,
                             SponserName = ad.Name,
                             FatherName = af.Name,
                             ProductName = a.Product.Name,

                         }).AsEnumerable();

            return View(users);
        }
        public IActionResult Direct()
        {
            var directlist = (from a in _db.AccountUsers
                              join ad in _db.AccountUsers on a.SponserId equals ad.Id
                              join af in _db.AccountUsers on a.FatherId equals af.Id
                              
                              where a.SponserId==ModelGloble.loginuser.loignid
                              select new ModelDisplayUsers
                              {
                                 UserAccount=a,
                                 SponserID=ad.AccountId,
                                  SponserName=ad.Name,
                                  FatherID=af.AccountId,
                                  FatherName=af.Name,
                                  ProductName=a.Product.Name,
                                  
                              }).AsEnumerable();
                
                //_db.AccountUsers.Where(w => w.SponserId == ModelGloble.loginuser.loignid).AsEnumerable();
            return View(directlist);
        }

        public IActionResult TreeList()
        {
            var directlist = (from t in _db.TreeRelation
                              join a in _db.AccountUsers on t.Accountid equals a.Id
                              join ad in _db.AccountUsers on a.SponserId equals ad.Id
                              join af in _db.AccountUsers on a.FatherId equals af.Id
                              where t.Upperid == ModelGloble.loginuser.loignid
                              select new ModelDisplayUsers
                              {
                                  UserAccount = a,
                                  SponserID = ad.AccountId,
                                  SponserName = ad.Name,
                                  FatherID = af.AccountId,
                                  FatherName = af.Name,
                                  ProductName = a.Product.Name,

                              }).AsEnumerable();

            //_db.AccountUsers.Where(w => w.SponserId == ModelGloble.loginuser.loignid).AsEnumerable();
            return View(directlist);
        }

        public IActionResult GetUserName(string accountid)
        {
            var user = _db.AccountUsers.Where(w => w.AccountId == accountid).FirstOrDefault();
            if (user != null && user.DisplayName.Length > 0)
            {
                return Ok(user.DisplayName);
            }
            return Ok("ID not correct");
        }
        public IActionResult GetSides(string accountid)
        {
            string returnstring = "0";
            if (accountid.Length > 0)
            {

                var rootid = _db.AccountUsers.Where(w => w.AccountId == accountid).Select(s => s.Id).FirstOrDefault();
                var childs = _db.AccountUsers.Where(w => w.FatherId == rootid).AsEnumerable();
                if (childs.Where(w => w.Side == 1).Count() == 0)
                    returnstring += "1";
                if (childs.Where(w => w.Side == 2).Count() == 0)
                    returnstring += "2";
            }
            return Ok(returnstring);
        }
        public Products GetPinProduct(string pincode)
        {
            return _db.Pins.Where(d => d.PinCode == pincode).Select(s => s.Order.Product).FirstOrDefault();
        }
        public IActionResult Join(string pincode)
        {
            var cuser = HttpContext.Session.Get<LoginUser>("loginuser");
            return View(new ModelUserJoin() { Pincode = pincode, Sponserid = _db.AccountUsers.Where(w => w.Id == cuser.loignid).Select(s => s.AccountId).FirstOrDefault() });
        }
        [HttpPost]
        public IActionResult Join(ModelUserJoin model)
        {
            if (ModelState.IsValid)
            {

                // check pin 
                if (_db.Pins.Where(w => w.PinCode == model.Pincode & w.UsedDate == null).Count() == 1)
                {

                    Products pinproduct = GetPinProduct(model.Pincode);

                    // sponser exists, root exists and side is blank
                    var sponser= _db.AccountUsers.Where(w => w.AccountId == model.Sponserid).FirstOrDefault();
                    if (sponser.DisplayName.Length > 3)
                    {
                        var father = _db.AccountUsers.Where(w => w.AccountId == model.RootId).FirstOrDefault();
                        if (father.DisplayName.Length > 3)
                        {
                            if (_db.AccountUsers.Where(w => w.FatherId == father.Id & w.Side == model.JoiningSide).Count() == 0)
                            {
                                using (var dbtrain = _db.Database.BeginTransaction())
                                {
                                    try
                                    {

                                        #region id genration 
                                        string accountID = ((DateTime.Now.Day + 10) + "" + (DateTime.Now.Year + 10) + "" + (DateTime.Now.Month + 10)).ToString();
                                        if (_db.AccountUsers.Count() > 0)
                                        {
                                            Random rand = new Random(3);
                                            while (true)
                                            {
                                                string lastid = rand.Next(1, 99).ToString().PadLeft(2, '0');
                                                if (_db.AccountUsers.Where(w => w.AccountId == (accountID + lastid)).FirstOrDefault() == null)
                                                {
                                                    accountID += lastid;
                                                    break;
                                                }
                                            }

                                        }
                                        #endregion


                                        bool topup = false;
                                        if (pinproduct.JoiningAmount == pinproduct.ProductAmount)
                                        {
                                            topup = true;
                                        }
                                        // now ok to join user
                                        AccountUsers newuser = new AccountUsers()
                                        {
                                            Activate = true,
                                            AccountId = accountID,
                                            DisplayName = model.ApplicationName,
                                            Name = model.ApplicationName,
                                            JoiningAmount = pinproduct.JoiningAmount,
                                            Password = model.Password,
                                            ProductId = pinproduct.Id,
                                            Side = (byte)model.JoiningSide,
                                            SponserId = sponser.Id,
                                            FatherId = father.Id,
                                            Date = DateTime.Now,
                                            SuperUser = false,
                                            Status = true,
                                            Topup = topup,
                                            TopupDate = DateTime.Now,
                                            Tpassword = new Random().Next(1111, 9999).ToString()

                                        };
                                        _db.AccountUsers.Add(newuser);

                                        _db.SaveChanges();

                                        decimal mobileno;
                                        decimal.TryParse(model.Mobile, out mobileno);
                                        PrasnalDetails Candidate = new PrasnalDetails()
                                        {
                                            AccountUserId = newuser.Id,
                                            Email = model.Email,
                                            Dob = model.Dateofbirth,
                                            Gender = model.Gender,
                                            Mobile = mobileno,
                                            PanCard = model.PanCard,
                                        };

                                        _db.PrasnalDetails.Add(Candidate);

                                        var currentpin = _db.Pins.Where(w => w.PinCode == model.Pincode).FirstOrDefault();
                                        currentpin.UsedBy = newuser.Id;
                                        currentpin.UsedDate = DateTime.Now;

                                        _db.SaveChanges();

                                        _db.Database.ExecuteSqlCommand($"sp_TreeUpdate {newuser.Id},{newuser.FatherId},{newuser.Side}");

                                        dbtrain.Commit();
                                        SendSMS.Joining(newuser.AccountId, newuser.DisplayName, Candidate.Mobile.ToString(), newuser.Password, newuser.Tpassword);
                                        try
                                        {
                                            LoginUser _LoginUser = HttpContext.Session.Get<LoginUser>("loginuser");
                                            if (_LoginUser != null && _LoginUser.loignid>0)
                                            {
                                                HttpContext.Session.SetAlert(new Alertmessage
                                                {
                                                    Message = $"User !{newuser.DisplayName} Joining Success ",
                                                    Type = Alerttype.success
                                                });
                                                return RedirectToAction("Unused","Pin");
                                            }
                                            else
                                            {
                                                return RedirectToAction("Login", "Auth");
                                            }
                                        }
                                        catch (Exception ed)
                                        {
                                            return RedirectToAction("Login", "Auth");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        dbtrain.Rollback();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return View(model);
        }
    }
}