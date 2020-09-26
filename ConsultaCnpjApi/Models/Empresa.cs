using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaCnpjApi.Models
{
    public class Empresa
    {
        private Atividade_Principal[] atividade_principal { get; set; }
        private string data_situacao { get; set; }
        private string tipo { get; set; }
        private string nome { get; set; }
        private string uf { get; set; }
        private string telefone { get; set; }
        private string email { get; set; }
        private Atividades_Secundarias[] atividades_secundarias { get; set; }
        private Qsa[] qsa { get; set; }
        private string situacao { get; set; }
        private string bairro { get; set; }
        private string logradouro { get; set; }
        private string numero { get; set; }
        private string cep { get; set; }
        private string municipio { get; set; }
        private string porte { get; set; }
        private string abertura { get; set; }
        private string natureza_juridica { get; set; }
        private string fantasia { get; set; }
        private string cnpj { get; set; }
        private DateTime ultima_atualizacao { get; set; }
        private string status { get; set; }
        private string complemento { get; set; }
        private string efr { get; set; }
        private string motivo_situacao { get; set; }
        private string situacao_especial { get; set; }
        private string data_situacao_especial { get; set; }
        private string capital_social { get; set; }
        private Extra extra { get; set; }
        private Billing billing { get; set; }
    }
}