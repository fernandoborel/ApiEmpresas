using ApiEmpresas.Infra.Data.Contexts;
using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresas.Infra.Data.Repositories;

public class FuncionarioRepository : IFuncionarioRepository
{
    //atributo
    private readonly SqlServerContext _context;

    public FuncionarioRepository(SqlServerContext context)
    {
        _context = context;
    }

    public void Inserir(Funcionario obj)
    {
        _context.Entry(obj).State = EntityState.Added;
        _context.SaveChanges();
    }

    public void Alterar(Funcionario obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Excluir(Funcionario obj)
    {
        _context.Entry(obj).State = EntityState.Deleted;
        _context.SaveChanges();
    }

    public List<Funcionario> Consultar()
    {
        return _context.Funcionario
            .Include(f => f.Empresa) //inner join
            .OrderBy(f => f.Nome)
            .ToList();
    }

    public Funcionario ObterPorId(Guid id)
    {
        return _context.Funcionario
            .Include(f => f.Empresa) //inner join
            .FirstOrDefault(f => f.IdFuncionario.Equals(id));
    }

    public Funcionario ObterPorCpf(string cpf)
    {
        return _context.Funcionario
            .Include(f => f.Empresa) //inner join
            .FirstOrDefault(f => f.Cpf.Equals(cpf));
    }

    public Funcionario ObterPorMatricula(string matricula)
    {
        return _context.Funcionario
            .Include(f => f.Empresa) //inner join
            .FirstOrDefault(f => f.Matricula.Equals(matricula));
    }

    public List<Funcionario> ObterPorNome(string nome)
    {
        return _context.Funcionario
            .Include(f => f.Empresa) //inner join
            .Where(f => f.Nome.Contains(nome))
            .OrderBy(f => f.Nome)
            .ToList();
    }
}
