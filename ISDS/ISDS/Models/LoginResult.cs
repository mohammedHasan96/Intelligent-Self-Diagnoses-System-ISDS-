using System;
using System.Collections.Generic;
using System.Text;

namespace ISDS.Models
{
    public class LoginResult
    {
        public int StateCode { get; set; }
        public string Message { get; set; }
        public string State { get; set; }
        public string Result { get; set; }
    }
}
