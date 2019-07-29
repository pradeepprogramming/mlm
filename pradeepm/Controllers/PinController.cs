using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pradeepm.Models;
using pradeepm.Models.DB;

namespace pradeepm.Controllers
{
    public class PinController : Controller
    {
        therisingstarContext _db;
        
        public PinController(therisingstarContext context)
        {
            _db = context;
           
        }
        public IActionResult Index()
        {

            IEnumerable<Pins> pinlist = null;
            if (ModelGloble.loginuser.usertype == "admin")
                pinlist = _db.Pins.AsEnumerable();
            else
                pinlist = _db.Pins.Where(w => w.ForUser == ModelGloble.loginuser.loignid).AsEnumerable();
            return View(pinlist);
        }
        public IActionResult Used()
        {
            IEnumerable<Pins> pinlist = null;
            if (ModelGloble.loginuser.usertype == "admin")
                pinlist = _db.Pins.Where(w => w.UsedBy != null).AsEnumerable();
            else
                pinlist=_db.Pins.Where(w=>w.ForUser==ModelGloble.loginuser.loignid && w.UsedBy!=null).AsEnumerable();
            return View(pinlist);
        }
        public IActionResult Unused()
        {
            IEnumerable<Pins> pinlist = null;
            if (ModelGloble.loginuser.usertype == "admin")
                pinlist = _db.Pins.Where(w=>w.UsedBy==null).AsEnumerable();
            else
                pinlist = _db.Pins.Where(w => w.ForUser == ModelGloble.loginuser.loignid && w.UsedBy == null).AsEnumerable();
            return View(pinlist);
        }

        [HttpGet]
        public IActionResult Genrate()
        {
            IEnumerable<Modeldropdown> accountlist = _db.AccountUsers.Select(s => new Modeldropdown { id = s.Id.ToString(), value = s.AccountId + " - " + s.DisplayName });
            ViewBag.accountlist = accountlist;
            IEnumerable<Modeldropdown> productlist = _db.Products.Select(s => new Modeldropdown { id = s.Id.ToString(), value = s.Name + " - " + s.ProductAmount });
            ViewBag.productlist = productlist;

            return View(new ModelGenratePin());
        }

        [HttpPost]
        public IActionResult Genrate(ModelGenratePin model)
        {
            if(ModelState.IsValid)
            {
                PinOrders order = new PinOrders()
                {
                    OrderByUserId = model.UserId,
                    ProductId = (byte)model.ProductId,
                    PinQty = model.PinCount,
                    OrderDate = DateTime.Now
                };
                _db.PinOrders.Add(order);
                _db.SaveChanges();
                //db.Entry(order).GetDatabaseValues();
                // now genrate pins and save to mypin

                for (int i = 1; i <= model.PinCount; i++)
                {
                    var dt = DateTime.Now;
                    string plaintext = order.Id.ToString() + i.ToString() + RandomString(8)+dt.Second+""+dt.Millisecond;
                    
                    Pins pin = new Pins()
                    {
                        PinCode = plaintext,
                        OrderId = order.Id,
                        ForUser = order.OrderByUserId
                    };

                    _db.Pins.Add(pin);
                }

                if (_db.SaveChanges() > 0)
                {
                    return RedirectToAction("Genrate");
                }
                
            }
            return View(model);
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        
        public IActionResult IsPinValid(string pincode)
        {
            if(pincode.Length>9)
            {
                var pin = _db.Pins.Where(w => w.PinCode == pincode).FirstOrDefault();
                if(pin!=null && pin.PinCode==pincode)
                {
                    return Ok("success");
                }
                else
                {
                    return Ok("error");
                }
            }
            return Ok("error");
        }
    }
}