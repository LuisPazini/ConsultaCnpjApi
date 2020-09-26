using ConsultaCnpjApi.Models;
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
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST: api/Empresas
        public void Post([FromBody]string value)
        {
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
