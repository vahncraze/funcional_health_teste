using funcional_health_teste.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.RepositoryMock;

namespace Teste.Controllers
{
    class ContaTest
    {
        ContaRepositoryMock _contaRepositoryMock;

        [SetUp]
        public void Init()
        {
            _contaRepositoryMock = new ContaRepositoryMock();
        }

        [Test]
        public void ListarTodosSucesso()
        {
            var result = _contaRepositoryMock.ListarTodos();
        }

        [Test]
        public void SacarComSucesso()
        {
            var result = _contaRepositoryMock.Sacar("11111", 200);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SacarComErro()
        {
            Assert.Throws(Is.TypeOf<InvalidOperationException>(), () => _contaRepositoryMock.Sacar("11111", 300));
        }

        [Test]
        public void DepositarComSucesso()
        {
            var result = _contaRepositoryMock.Depositar("11111", 200);
            Assert.IsNotNull(result);
        }

        [Test]
        public void DepositarComErro()
        {
            Assert.Throws(Is.TypeOf<InvalidOperationException>(), () => _contaRepositoryMock.Depositar("11111", -200));
        }
    }
}
