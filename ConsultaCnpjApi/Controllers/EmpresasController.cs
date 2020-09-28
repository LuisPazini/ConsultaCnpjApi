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
using System.Web.UI.WebControls;

namespace ConsultaCnpjApi.Controllers
{
    public class EmpresasController : ApiController
    {
        // GET: api/Empresas
        public List<Empresa> Get()
        {
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    List<Empresa> empresas = new List<Empresa>();
                    contexto.Empresas.ForEach(e => empresas.Add(e));

                    return empresas;
                }
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar CNPJs");
            }
        }

        // GET: api/Empresas/{id}
        public Empresa Get(int id)
        {
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    Empresa empresa = contexto.Empresas.Find(id);
                    return empresa;
                }
            }
            catch (Exception)
            {

                throw new Exception("Erro ao consultar CNPJ");
            }
        }

        // POST: api/Empresas
        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync([FromBody] Empresa e)
        {
            Empresa empresa = new Empresa();

            // Consultando os dados na API da Receita
            try
            {
                ConsultaReceitaWs consulta = new ConsultaReceitaWs();
                empresa = await consulta.Consultar(e.Cnpj);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao consultar CNPJ na Receita");
            }

            // Adicionando a empresa no Banco de Dados
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    contexto.Empresas.Add(new Empresa()
                    {
                        Id = empresa.Id,
                        Atividade_Principal = empresa.Atividade_Principal,
                        Data_Situacao = empresa.Data_Situacao,
                        Tipo = empresa.Tipo,
                        Nome = empresa.Nome,
                        Uf = empresa.Uf,
                        Telefone = empresa.Telefone,
                        Email = empresa.Email,
                        Atividades_Secundarias = empresa.Atividades_Secundarias,
                        Qsa = empresa.Qsa,
                        Situacao = empresa.Situacao,
                        Bairro = empresa.Bairro,
                        Logradouro = empresa.Logradouro,
                        Numero = empresa.Numero,
                        Cep = empresa.Cep,
                        Municipio = empresa.Municipio,
                        Porte = empresa.Porte,
                        Abertura = empresa.Abertura,
                        Natureza_Juridica = empresa.Natureza_Juridica,
                        Fantasia = empresa.Fantasia,
                        Cnpj = empresa.Cnpj,
                        Ultima_Atualizacao = empresa.Ultima_Atualizacao,
                        Status = empresa.Status,
                        Complemento = empresa.Complemento,
                        Efr = empresa.Efr,
                        Motivo_Situacao = empresa.Motivo_Situacao,
                        Situacao_Especial = empresa.Situacao_Especial,
                        Data_Situacao_Especial = empresa.Data_Situacao_Especial,
                        Capital_Social = empresa.Capital_Social,
                        Extra = empresa.Extra,
                        Billing = empresa.Billing
                    });

                    contexto.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw new Exception("Erro ao cadastrar CNPJ");
            }
            return Ok();
        }

        // DELETE: api/Empresas/{id}
        public void Delete(int id)
        {
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    contexto.Empresas.Remove(contexto.Empresas.Find(id));
                }
            }
            catch (Exception)
            {

                throw new Exception("Erro ao remover CNPJ");
            }
        }
    }
}
