using funcional_health_teste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health_teste.IService
{
    public interface IContaService
    {
        IQueryable<Conta> ListarTodos();
        Conta ObterPorId(Guid id);
        Conta Sacar(string numeroConta,float valor);
        Conta Depositar(string numeroConta,float valor);
        Conta Criar(string nome);
    }
}
