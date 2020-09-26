using ConsultaCnpjApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ConsultaCnpjApi.Resources.db
{
    public class Contexto : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Atividade_Principal> Atividades_Principais { get; set; }
        public DbSet<Atividades_Secundarias> Atividades_Secundarias { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Qsa> Qsas { get; set; }

    }
}