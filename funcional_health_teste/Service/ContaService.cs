using funcional_health_teste.IService;
using funcional_health_teste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health_teste.Service
{
    public class ContaService : IContaService
    {
        private IList<Conta> _conta;

        public ContaService()
        {
            _conta = new List<Conta>()
            {
                new Conta(){
                    Id = Guid.NewGuid(),
                    Nome="Bruno Soares Romano",
                    NumeroConta="11111",
                    Saldo = 100.0F
                },
                                new Conta(){
                    Id = Guid.NewGuid(),
                    Nome="Functional Health",
                    NumeroConta="22222",
                    Saldo = 200.0F
                }
            };
        }
        public IQueryable<Conta> ListarTodos()
        {
            return _conta.AsQueryable();
        }

        public Conta Depositar(string numeroConta, float valor)
        {
            if (valor < 0)
                throw new Exception("Valor não pode ser negativo.");

            var conta = _conta.FirstOrDefault(x => x.NumeroConta == numeroConta);
            if (conta == null)
                throw new Exception("Conta não encontrada.");

            conta.Saldo += valor;
            _conta.Add(conta);

            return conta;
        }

        public Conta Sacar(string numeroConta, float valor)
        {
            var conta = _conta.FirstOrDefault(x => x.NumeroConta == numeroConta);
            if (conta == null)
                throw new Exception("Conta não encontrada.");

            if (conta.Saldo < valor)
                throw new Exception("Saldo insuficiente.");

            conta.Saldo -= valor;
            _conta.Add(conta);

            return conta;
        }

        public Conta ObterPorId(Guid id)
        {
            return _conta.FirstOrDefault(x => x.Id == id);
        }

        public float Saldo(string numeroConta)
        {
            return _conta.FirstOrDefault(x => x.NumeroConta == numeroConta).Saldo;
        }

        public Conta Criar(string nome)
        {
            Random rnd = new Random();
            Conta novaConta = new Conta
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                NumeroConta = rnd.Next(0, 99999).ToString(),
                Saldo = 0
            };

            _conta.Add(novaConta);
            return novaConta;
        }
    }
}
