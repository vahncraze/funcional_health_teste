using funcional_health_teste.IService;
using funcional_health_teste.Models;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health_teste.GraphQL
{
    public class ContaType:ObjectType<Conta>
    {
        protected override void Configure(IObjectTypeDescriptor<Conta> descriptor)
        {
            descriptor.Field(x => x.Id).Type<IdType>();
            descriptor.Field(x => x.NumeroConta).Type<StringType>();
            descriptor.Field(x => x.Nome).Type<StringType>();
            descriptor.Field(x => x.Saldo).Type<FloatType>();

            descriptor.Field<ContaResolver>(x => x.GetConta(default, default));
        }
    }

    public class ContaResolver
    {
        private readonly IContaService _contaService;

        public ContaResolver([Service] IContaService contaService)
        {
            _contaService = contaService;
        }

        public IEnumerable<Conta> GetConta(Conta conta, IResolverContext ctx)
        {
            return _contaService.ListarTodos().Where(x => x.NumeroConta == conta.NumeroConta);
        }
    }
}
