using CommonLib;
using System.Collections.Generic;
using CisNet.Types;

namespace CisNet.Models
{
    public class ModelDb
    {
        public bool CheckUser(string username, string password)
        {
            if (username == "Alex" && password == "123") return true;
            return false;
        }

        public List<Bypass> GetBypassList()
        {
            return Bypass.getTestData();
        }
    }


}
