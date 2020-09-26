using ConsultaCnpjApi.Service;
using System;

namespace ConsultaEmpresa
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultaEmpresaService consulta = new ConsultaEmpresaService();
            Console.Write(consulta.consultar("13646769000123"));
        }
    }
}
