using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaCnpjApi.Models
{
    public class Billing
    {
        public int Id { get; set; }
        public bool Free { get; set; }
        public bool Database { get; set; }
    }
}