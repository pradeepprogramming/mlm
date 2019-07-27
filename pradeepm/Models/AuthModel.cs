using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pradeepm.Models
{
    public class LoginModel
    {
        public string userid { get; set; }
        public string password { get; set; }
    }

    public class LoginUser
    {
        public int loignid { get; set; }
        public string usertype { get; set; }
        
        public string username { get; set; }
    }
    public enum Alerttype {success,error,warning };
    public class Alertmessage
    {
        public Alerttype Type { get; set; }
        public string Message { get; set; }
    }

}
