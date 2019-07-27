using Microsoft.AspNetCore.Mvc;
using pradeepm.Models;
using pradeepm.Models.BL;
using pradeepm.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pradeepm.Components
{
    
    public class UserIncomeDetails:ViewComponent
    {
        User _user;
        public UserIncomeDetails(User user)
        {
            _user = user;
        }
        public async Task<IViewComponentResult> InvokeAsync(int userid)
        {
            
            return View();
        }
        
    }
}
