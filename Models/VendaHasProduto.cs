using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final.Models
{
    //[Keyless]
    [Table("VendaHasProduto")]
    public class VendaHasProduto
    {
        [Column("VendaHasProdutoId")]
        [Display(Name = "Código da Veda do Produto")]
        public int VendaHasProdutoId { get; set; }

        [ForeignKey("VendaId")]
        public int VendaId { get; set; }

        public Venda? Venda { get; set; }

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }

        public Produto? Produto { get; set; }

    }
}
