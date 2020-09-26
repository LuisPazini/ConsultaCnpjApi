using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaCnpjApi.Models
{
    public class Billing
    {
        public int Id { get; set; }
        public bool free { get; set; }
        public bool database { get; set; }
    }
}