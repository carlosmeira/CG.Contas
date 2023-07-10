using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CG.Contas.API.Models
{
    public class Conta
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;
    }
}