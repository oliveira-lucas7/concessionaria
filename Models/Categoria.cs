﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Column("CategoriaId")]
        [Display(Name = "Código da categoria")]
        public int CategoriaId { get; set; }

        [Column("NomeCategoria")]
        [Display(Name = "Nome da categoria")]
        public string CategoriaName { get; set; } = string.Empty;
    }
}
