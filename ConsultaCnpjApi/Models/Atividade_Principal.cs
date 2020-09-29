using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaCnpjApi.Models
{
    public class Atividade_Principal
    {
        public int Id { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
    }
}