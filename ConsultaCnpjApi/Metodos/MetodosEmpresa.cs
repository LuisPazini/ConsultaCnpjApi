using ConsultaCnpjApi.Resources.db;
using ConsultaCnpjApi.Services;
using System;

namespace ConsultaCnpjApi.Models
{
    public partial class CadastroEmpresaService : Empresa
    {
        public async void SalvarAsync(Empresa e)
        {
            try
            {
                // Consultando os dados na API da Receita
                ConsultaReceitaWs consulta = new ConsultaReceitaWs();
                Empresa empresa = await consulta.Consultar(e.Cnpj);

                // Adicionando a empresa no Banco de Dados
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
                throw;
            }
        }
    }
}