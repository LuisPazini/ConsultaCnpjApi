
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaCnpjApi.Models
{
    public class Qsa
    {
        public int Id { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
        public string Qual { get; set; }
        public string Nome { get; set; }
    }
}