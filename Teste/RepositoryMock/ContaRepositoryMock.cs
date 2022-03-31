using funcional_health_teste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.RepositoryMock
{
    class ContaRepositoryMock
    {
        public void Incluir(Conta conta)
        {
        }

        public Conta ObterPorId(Guid id)
        {
            return Contas.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Conta> ListarTodos()
        {
            return Contas;
        }

        public Conta Sacar(string numeroConta, float valor)
        {
            var conta = Contas.FirstOrDefault(x => x.NumeroConta == numeroConta);
            if (conta == null)
                throw new InvalidOperationException("Conta não encontrada.");

            if (conta.Saldo < valor)
                throw new InvalidOperationException("Saldo insuficiente.");

            conta.Saldo -= valor;

            return conta;
        }


        public Conta Depositar(string numeroConta, float valor)
        {
            if (valor < 0)
                throw new InvalidOperationException("Valor não pode ser negativo.");

            var conta = Contas.FirstOrDefault(x => x.NumeroConta == numeroConta);
            if (conta == null)
                throw new InvalidOperationException("Conta não encontrada.");



            conta.Saldo += valor;

            return conta;
        }

        private static IEnumerable<Conta> Contas
        {
            get
            {
                var conta1 = new Conta
                {
                    Id = Guid.NewGuid(),
                    Nome = "Bruno Soares Romano",
                    NumeroConta = "11111",
                    Saldo = 200
                };

                var conta2 = new Conta
                {
                    Id = Guid.NewGuid(),
                    Nome = "Functional Health",
                    NumeroConta = "22222",
                    Saldo = 500
                };

                return new Conta[]
                    {
                        conta1,
                        conta2
                    };
            }
        }
    }
}
