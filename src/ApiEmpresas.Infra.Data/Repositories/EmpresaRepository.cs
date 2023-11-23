using ApiEmpresas.Infra.Data.Contexts;
using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresas.Infra.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para a injeção de dependência
        public EmpresaRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Inserir(Empresa obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(Empresa obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Empresa obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Empresa> Consultar()
        {
            return _context.Empresa
                .OrderBy(e => e.NomeFantasia)   
                .ToList();
        }

        public Empresa ObterPorCnpj(string cnpj)
        {
            return _context.Empresa
                .FirstOrDefault(e => e.Cnpj.Equals(cnpj));
        }

        public Empresa ObterPorId(Guid id)
        {
            return _context.Empresa
                .FirstOrDefault(e => e.IdEmpresa.Equals(id));
        }
    }
}
