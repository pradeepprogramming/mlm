using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using pradeepm.Models.DB;

namespace pradeepm.Models
{
    public class ModelMagicClub:Magicclub
    {
        [Display(Name ="Account name")]
        public string AccountName { get; set; }
        public string UserID { get; set; }
        public string ProfilePic { get; set; }
    }
}
