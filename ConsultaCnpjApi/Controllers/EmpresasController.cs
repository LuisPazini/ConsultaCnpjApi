using ConsultaCnpjApi.Models;
using ConsultaCnpjApi.Repository;
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
            List<Empresa> empresas;
            EmpresaRepository empresaRepository = new EmpresaRepository();

            try
            {
                empresas = empresaRepository.GetAll();

                if (empresas == null)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }

                //empresas.ForEach(e => empresaModelFactory.Create(e));

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
            EmpresaRepository empresaRepository = new EmpresaRepository();

            try
            {
                empresa = empresaRepository.GetEmpresa(id);

                if (empresa == null)
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }

                //empresa = empresaModelFactory.Create(empresa);

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
            EmpresaRepository empresaRepository = new EmpresaRepository();
            

            try
            {
                if (empresaRepository.IsCadastrada(e))
                {
                    throw new Exception("Empresa já cadastrada!");
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

            // Adicionando a empresa no Banco de Dados
            try
            {
                empresaRepository.Salvar(empresa);
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
            Empresa empresa;
            EmpresaRepository empresaRepository = new EmpresaRepository();

            try
            {
                empresa = empresaRepository.GetEmpresa(id);

                if (empresa == null)
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }

                empresaRepository.Remover(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover CNPJ: " + ex.Message);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
