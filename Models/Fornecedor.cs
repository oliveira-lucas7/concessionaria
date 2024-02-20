using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final.Models
{
    [Table("Fornecedor")]
    public class Fornecedor
    {
        [Column("FornecedorId")]
        [Display(Name = "Código do fornecedor")]
        public int Id { get; set; }

        [Column("CnpjFornecedor")]
        [Display(Name = "Cnpj do fornecedor")]
        public string CnpjForncedor { get; set; } = string.Empty;

        [Column("NomeFornecedor")]
        [Display(Name = "Nome do fornecedor")]
        public string NomeFornecedor { get; set; } = string.Empty;
    }
}
