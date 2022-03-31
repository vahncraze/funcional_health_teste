using funcional_health_teste.IService;
using funcional_health_teste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health_teste.Schema
{
    public class Mutation
    {
        private readonly List<Conta> _contas;

        public Mutation()
        {
            _contas = new List<Conta>();
        }

        public bool Create(string nome)
        {
            Random rnd = new Random();
            Conta novaConta = new Conta
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                NumeroConta = rnd.Next(0, 99999).ToString(),
                Saldo = 0
            };

            _contas.Add(novaConta);
            return true;
        }

        public List<Conta> Get()
        {
            return _contas;
        }

        public Conta GetConta(string numeroConta)
        {
            return _contas.FirstOrDefault(x => x.NumeroConta == numeroConta);
        }

        public Conta Depositar(string numeroConta, float valor)
        {
            var conta = _contas.FirstOrDefault(x => x.NumeroConta == numeroConta);
            conta.Saldo += valor;

            return conta;
        }

        public Conta Sacar(string numeroConta, float valor)
        {

            var conta = _contas.FirstOrDefault(x => x.NumeroConta == numeroConta);
            if (conta == null)
                throw new Exception("Conta não encontrada.");

            if (conta.Saldo < valor)
                throw new Exception("Saldo insuficiente.");

            conta.Saldo -= valor;

            return conta;
        }

        public float Saldo(string numeroConta)
        {

            var conta = _contas.FirstOrDefault(x => x.NumeroConta == numeroConta);
            if (conta == null)
                throw new Exception("Conta não encontrada.");

            return conta.Saldo;

        }
    }
}
