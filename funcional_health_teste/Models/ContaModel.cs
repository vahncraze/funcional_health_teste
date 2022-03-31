using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health_teste.Models
{
    public class Conta
    {
        public Guid Id { get; set; }
        public string  NumeroConta { get; set; }
        public string Nome { get; set; }
        public float Saldo { get; set; }
    }
}
