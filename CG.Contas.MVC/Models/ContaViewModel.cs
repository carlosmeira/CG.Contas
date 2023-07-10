using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CG.Contas.MVC.Models
{

    public class ContaViewModel
    {
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required]
        [MinLength(3)]
        public string Nome { get; set; } = string.Empty;

        [DisplayName("Descrição")]
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Descricao { get; set; } = string.Empty;
    }
}