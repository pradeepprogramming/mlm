using pradeepm.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pradeepm.Models.BL
{
    public class User
    {
        therisingstarContext _db;
        public User(therisingstarContext context) => _db = context;


    }
}
