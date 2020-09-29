using ConsultaCnpjApi.Models;
using ConsultaCnpjApi.Resources.db;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace ConsultaCnpjApi.Repository
{
    public class EmpresaRepository
    {
        public List<Empresa> GetAll()
        {
            List<Empresa> _el = new List<Empresa>();

            using (Contexto contexto = new Contexto())
            {
                _el = contexto.Empresas.ToList();

                if(_el == null)
                {
                    return null;
                }

                _el.ForEach(e => e.Atividade_Principal = contexto.Atividades_Principais.Where(a => a.EmpresaId == e.Id).ToList());
                _el.ForEach(e => e.Atividades_Secundarias = contexto.Atividades_Secundarias.Where(a => a.EmpresaId == e.Id).ToList());
                _el.ForEach(e => e.Qsa = contexto.Qsas.Where(q => q.EmpresaId == e.Id).ToList());
            }

            return _el;
        }

        public Empresa GetEmpresa(int empresaId)
        {
            Empresa _e;

            using (Contexto contexto = new Contexto())
            {
                _e = contexto.Empresas.Find(empresaId);

                if(_e == null)
                {
                    return null;
                }

                _e.Atividade_Principal = contexto.Atividades_Principais.Where(a => a.EmpresaId == _e.Id).ToList();
                _e.Atividades_Secundarias = contexto.Atividades_Secundarias.Where(a => a.EmpresaId == _e.Id).ToList();
                _e.Qsa = contexto.Qsas.Where(q => q.EmpresaId == _e.Id).ToList();
            }

            return _e;
        }

        public bool IsCadastrada(Empresa empresa)
        {
            using (Contexto contexto = new Contexto())
            {
                if (contexto.Empresas.Any(empr => empr.Cnpj == empresa.Cnpj))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Salvar(Empresa empresa)
        {
            using (Contexto contexto = new Contexto())
            {
                // Removendo caracteres especiais
                //empresa.Cnpj.Replace(".", "");
                //empresa.Cnpj.Replace("/", "");
                //empresa.Cnpj.Replace("-", "");

                // Inserindo os registros das tabelas auxiliares
                empresa.Atividade_Principal.ForEach(a => contexto.Atividades_Principais.Add(a));
                empresa.Atividades_Secundarias.ForEach(a => contexto.Atividades_Secundarias.Add(a));
                empresa.Qsa.ForEach(q => contexto.Qsas.Add(q));

                // Inserindo o registro da empresa
                contexto.Empresas.Add(empresa);

                contexto.SaveChanges();
            }
        }

        public void Remover(Empresa empresa)
        {
            using (Contexto contexto = new Contexto())
            {
                // Removendo os registros das tabelas auxiliares
                contexto.Atividades_Principais.Where(a => a.EmpresaId == empresa.Id)
                    .ForEach(a => contexto.Atividades_Principais.Remove(a));
                contexto.Atividades_Secundarias.Where(a => a.EmpresaId == empresa.Id)
                    .ForEach(a => contexto.Atividades_Secundarias.Remove(a));
                contexto.Qsas.Where(q => q.EmpresaId == empresa.Id)
                    .ForEach(q => contexto.Qsas.Remove(q));

                // Removendo o registro da empresa
                contexto.Empresas.Where(e => e.Id == empresa.Id)
                    .ForEach(e => contexto.Empresas.Remove(e));

                contexto.SaveChanges();
            }
        }
    }
}