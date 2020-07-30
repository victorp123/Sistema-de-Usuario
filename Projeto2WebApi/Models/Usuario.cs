using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto2WebApi.Models
{
    public class Usuario
    {
        [Key]
        public int cod_cliente { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string nome { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string sobrenome { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string cpf { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string telResidencial { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string telCelular { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string rg { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string email { get; set; }

        public Cidade cidade { get; set; }
        public int cod_cidade { get; set; }

    }
}