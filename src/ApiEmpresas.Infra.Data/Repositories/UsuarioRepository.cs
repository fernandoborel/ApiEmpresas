using ApiEmpresas.Infra.Data.Contexts;
using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresas.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para injeção de dependência
        public UsuarioRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Inserir(Usuario obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(Usuario obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Usuario obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Usuario> Consultar()
        {
            return _context.Usuario
                .OrderBy(u => u.Nome)
                .ToList();
        }
        public Usuario ObterPorId(Guid id)
        {
            return _context.Usuario
                .FirstOrDefault(u => u.IdUsuario.Equals(id));
        }

        public Usuario Obter(string email)
        {
            return _context.Usuario
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario Obter(string email, string senha)
        {
            return _context.Usuario
                .FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }

    }
}
