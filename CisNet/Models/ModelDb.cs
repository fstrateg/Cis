using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CisNet.Models
{
    public class ModelDb
    {
        public bool CheckUser(string username, string password)
        {
            if (username == "Alex" && password == "123") return true;
            return false;
        }
    }
}
