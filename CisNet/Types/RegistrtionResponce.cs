using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CisNet.Types
{
    public class RegistrtionResponce
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Username { get; set; }
        public string Error { get; set; }
    }
}
