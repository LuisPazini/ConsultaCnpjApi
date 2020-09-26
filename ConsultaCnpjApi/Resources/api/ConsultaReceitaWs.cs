using ConsultaCnpjApi.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsultaCnpjApi.Services
{
    public class ConsultaReceitaWs
    {
        public async Task<Empresa> consultar(string cnpj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(string.Format("https://receitaws.com.br/v1/cnpj/"));
                var response = await client.GetAsync(cnpj);

                string dados = await response.Content.ReadAsStringAsync();

                Empresa empresa = new JavaScriptSerializer().Deserialize<Empresa>(dados);

                return empresa;
            }
        }
    }
}