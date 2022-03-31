using funcional_health_teste.IService;
using funcional_health_teste.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health_teste.GraphQL
{
    public class Query
    {
        private readonly IContaService _contaService;

        public Query(IContaService contaService)
        {
            _contaService = contaService;
        }

        public IQueryable<Conta> Contas => _contaService.ListarTodos();

    }
}
