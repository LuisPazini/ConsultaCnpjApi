using ConsultaCnpjApi.Models;
using ConsultaCnpjApi.Resources.db;
using ConsultaCnpjApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConsultaCnpjApi.Controllers
{
    public class EmpresasController : ApiController
    {
        // GET: api/Empresas
        public IEnumerable<Empresa> Get()
        {
            return null;
        }

        // GET: api/Empresas/5
        public async System.Threading.Tasks.Task<Empresa> GetAsync(string cnpj)
        {
                        
            return null;
        }

        // POST: api/Empresas
        public async System.Threading.Tasks.Task PostAsync([FromBody]string cnpj)
        {
            // Consultando os dados na API da Receita
            ConsultaReceitaWs consulta = new ConsultaReceitaWs();
            Empresa empresa = await consulta.Consultar(cnpj);

            // Adicionando a empresa no Banco de Dados
            using (Contexto contexto = new Contexto())
            {
                contexto.Empresas.Add(new Empresa()
                {
                    Id = empresa.Id,
                    Data_Situacao = empresa.Data_Situacao,
                    Tipo = empresa.Tipo,
                    Nome = empresa.Nome,
                    Uf = empresa.Uf,
                    Telefone = empresa.Telefone,
                    Email = empresa.Email
                });

                contexto.SaveChanges();
            }
        }

        // PUT: api/Empresas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empresas/5
        public void Delete(int id)
        {
        }
    }
}
