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
using System.Web.WebPages;
using WebGrease.Css.Extensions;

namespace ConsultaCnpjApi.Controllers
{
    public class EmpresasController : ApiController
    {
        EmpresaModelFactory empresaModelFactory;

        public EmpresasController()
        {
            empresaModelFactory = new EmpresaModelFactory();
        }

        // GET: api/Empresas
        public IHttpActionResult Get()
        {
            List<Empresa> empresas = new List<Empresa>();

            try
            {
                using (Contexto contexto = new Contexto())
                {

                    //empresas = contexto.Empresas.ToList().Select(e => empresaModelFactory.Create(e)).ToList();
                    empresas = contexto.Empresas.ToList();

                    if (empresas.Count() == 0)
                    {
                        return StatusCode(HttpStatusCode.NoContent);
                    }


                    empresas.ForEach(e => e.Atividade_Principal = contexto.Atividades_Principais.Where(a => a.EmpresaId == e.Id).ToList());
                    empresas.ForEach(e => e.Atividades_Secundarias = contexto.Atividades_Secundarias.Where(a => a.EmpresaId == e.Id).ToList());
                    empresas.ForEach(e => e.Qsa = contexto.Qsas.Where(q => q.EmpresaId == e.Id).ToList());
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar CNPJs: " + ex.Message);
            }

            return Ok(empresas);
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

                    //empresa = empresaModelFactory.Create(empresa);

                    //contexto.Atividades_Principais.Where(a => a.EmpresaId == empresa.Id)
                    //    .ForEach(a => empresa.Atividade_Principal.Add(a));

                    empresa.Atividade_Principal = contexto.Atividades_Principais.Where(a => a.EmpresaId == empresa.Id).ToList();
                    empresa.Atividades_Secundarias = contexto.Atividades_Secundarias.Where(a => a.EmpresaId == empresa.Id).ToList();
                    empresa.Qsa = contexto.Qsas.Where(q => q.EmpresaId == empresa.Id).ToList();

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
            

            try
            {
                using(Contexto contexto = new Contexto())
                {
                    if (contexto.Empresas.Any(empr => empr.Cnpj == e.Cnpj))
                    {
                        throw new Exception("Empresa já cadastrada!");
                    }
                }

                ConsultaReceitaWs consulta = new ConsultaReceitaWs();

                // Validação do CNPJ
                if (!ValidaCnpj.IsValidCnpj(e.Cnpj))
                {
                    throw new Exception("Cnpj inválido.");
                }

                // Consultando os dados na API da Receita
                empresa = await consulta.Consultar(e.Cnpj);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar CNPJ na Receita: " + ex.Message);
            }

            empresa.Cnpj.Replace(".", "");
            empresa.Cnpj.Replace("/", "");
            empresa.Cnpj.Replace("-", "");
            var _empresa = empresa.Cnpj.AsInt();


            // Adicionando a empresa no Banco de Dados
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    empresa.Atividade_Principal.ForEach(a => contexto.Atividades_Principais.Add(a));
                    empresa.Atividades_Secundarias.ForEach(a => contexto.Atividades_Secundarias.Add(a));
                    empresa.Qsa.ForEach(q => contexto.Qsas.Add(q));

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
