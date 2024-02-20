using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("ClienteId")]
        [Display(Name = "Código do cliente")]
        public int ClienteId { get; set; }

        [Column("NomeCliente")]
        [Display(Name = "Nome do cliente")]
        public string NomeCliente { get; set; } = string.Empty;

        [Column("CpfCliente")]
        [Display(Name = "Cpf do cliente")]
        public string CpfCliente { get; set; } = string.Empty;

        [Column("IdadeCliente")]
        [Display(Name = "Idade do cliente")]
        public int IdadeCliente { get; set; }
    }
}
