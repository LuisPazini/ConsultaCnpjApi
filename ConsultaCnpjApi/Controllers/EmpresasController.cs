using ConsultaCnpjApi.Models;
using ConsultaCnpjApi.Resources.db;
using ConsultaCnpjApi.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;

namespace ConsultaCnpjApi.Controllers
{
    public class EmpresasController : ApiController
    {
        // GET: api/Empresas
        public IHttpActionResult Get()
        {
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    List<Empresa> empresas = new List<Empresa>();
                    contexto.Empresas.ForEach(e => empresas.Add(e));

                    if(empresas.Count() == 0)
                    {
                        return StatusCode(HttpStatusCode.NoContent);
                    }

                    return Ok(empresas);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar CNPJs: " + ex.Message);
            }
        }

        // GET: api/Empresas/{id}
        public IHttpActionResult Get(int id)
        {
            Empresa empresa;
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    empresa = contexto.Empresas.Find(id);
                    if (empresa == null)
                    {
                        return StatusCode(HttpStatusCode.NotFound);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar CNPJ: " + ex.Message);
            }
            return Ok(empresa);
        }

        // POST: api/Empresas
        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync([FromBody] Empresa e)
        {
            Empresa empresa;

            // Consultando os dados na API da Receita
            try
            {
                ConsultaReceitaWs consulta = new ConsultaReceitaWs();
                empresa = await consulta.Consultar(e.Cnpj);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar CNPJ na Receita: " + ex.Message);
            }

            // Adicionando a empresa no Banco de Dados
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    contexto.Empresas.Add(empresa);

                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar CNPJ: " + ex.Message);
            }
            return StatusCode(HttpStatusCode.Created);
        }

        // DELETE: api/Empresas/{id}
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    Empresa empresa = contexto.Empresas.Find(id);
                    if(empresa == null)
                    {
                        return StatusCode(HttpStatusCode.NotFound);
                    }
                    contexto.Empresas.Remove(empresa);

                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover CNPJ: " + ex.Message);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
