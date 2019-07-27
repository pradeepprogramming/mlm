using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pradeepm.Models
{
    public class Menus
    {
        public string lavel { get; set; }
        public List<MainMenuItems> menuitems { get; set; }
    }
    public class MenuFor
    {
        /// <summary>
        /// if user type is "" then all user can access this menu otherwise if user type match or contains that usertypename
        /// </summary>
        public string usertype { get; set; }
        public string icon { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
    public class ChildrenItems:MenuFor
    {
        public string state { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<ChildrenItems> childrens { get; set; }
       
}

    public class MainMenuItems:MenuFor
    {
        public string state { get; set; }
        public string shortlabel { get; set; }
        public string mainstate { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        
        public List<ChildrenItems> childrens { get; set; }

    }
    

}
