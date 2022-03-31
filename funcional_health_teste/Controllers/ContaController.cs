using funcional_health_teste.IService;
using funcional_health_teste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health_teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : Controller
    {
        private readonly IContaService _contaService;


        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        public ContaController()
        {
        }

        [HttpPost]
        public ActionResult Post([FromBody] string nome)
        {
            var resultado = _contaService.Criar(nome);

            return Created($"/conta/{resultado.Id}", resultado);
        }

        [HttpPatch]
        [Route("sacar")]
        public ActionResult Sacar([FromBody]  SaqueModel saque)
        {
            var resultado = _contaService.Sacar(saque.NumeroConta,saque.Valor);

            return Ok(resultado);
        }

        [HttpPatch]
        [Route("depositar")]
        public ActionResult Depositar([FromBody] DepositarModel deposito)
        {
            var resultado = _contaService.Depositar(deposito.NumeroConta, deposito.Valor);

            return Ok(resultado);
        }
    }
}
