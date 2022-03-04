using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwt.Models
{
    public class ResponseAuthentication
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}