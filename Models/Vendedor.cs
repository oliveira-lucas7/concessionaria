using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {
        [Column("VendedorId")]
        [Display(Name = "Código do vendedor")]
        public int VendedorId { get; set; }

        [Column("NomeVendedor")]
        [Display(Name = "Nome do vendedor")]
        public string NomeVendedor { get; set; } = string.Empty;

        [Column("IdadeVendedor")]
        [Display(Name = "Idade do Vendedor")]
        public int IdadeVendedor { get; set; }

        [Column("CpfVendedor")]
        [Display(Name = "Cpf do vendedor")]
        public string CpfVendedor { get; set; } = string.Empty;
    }
}