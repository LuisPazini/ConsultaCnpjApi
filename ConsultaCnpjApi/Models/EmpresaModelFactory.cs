using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaCnpjApi.Models
{
    public class EmpresaModelFactory
    {
        public Empresa Create(Empresa empresa)
        {
            return new Empresa()
            {
                Atividade_Principal = (List<Atividade_Principal>)empresa.Atividade_Principal.Select(a => Create(a)),
                Data_Situacao = empresa.Data_Situacao,
                Tipo = empresa.Tipo,
                Nome = empresa.Nome,
                Uf = empresa.Uf,
                Telefone = empresa.Telefone,
                Email = empresa.Email,
                Atividades_Secundarias = (List<Atividades_Secundarias>)empresa.Atividades_Secundarias.Select(a => Create(a)),
                Qsa = (List<Qsa>)empresa.Qsa.Select(q => Create(q)),
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
            };
        }

        public Atividade_Principal Create(Atividade_Principal atividade_principal)
        {
            return new Atividade_Principal()
            {
                Text = atividade_principal.Text,
                Code = atividade_principal.Code
            };
        }

        public Atividades_Secundarias Create(Atividades_Secundarias atividades_secundarias)
        {
            return new Atividades_Secundarias()
            {
                Text = atividades_secundarias.Text,
                Code = atividades_secundarias.Code
            };
        }

        public Qsa Create(Qsa qsa)
        {
            return new Qsa()
            {
                Qual = qsa.Qual,
                Nome = qsa.Nome
            };
        }
    }
}