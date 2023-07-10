using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CG.Contas.API.Models
{
    public class Conta
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}