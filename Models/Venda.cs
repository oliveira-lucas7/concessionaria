using Projeto_Final.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final.Models
{
    [Table("Venda")]
    public class Venda
    {
        [Column("VendaId")]
        [Display(Name = "Código de venda")]
        public int Id { get; set; }

        [Column("ValorTotal")]
        [Display(Name = "Valor total da venda")]
        public double ValorTotal { get; set;}

        [Column("NomeVenda")]
        [Display(Name = "Nome da venda")]
        public double NomeVenda { get; set; }

        [Column("DataVenda")]
        [Display(Name = "Data da venda")]
        public DateTime VendaName { get; set;}

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente? cliente { get; set; }

        [ForeignKey("VendedorId")]
        public int VendedorId { get; set; }
        public Vendedor? Vendedor { get; set; }

        [ForeignKey("PagamentoId")]
        public int PagamentoId { get; set; }
        public Pagamento? Pagamento { get; set; }

        [NotMapped] //Essa propriedade é usada para que não seja criado essa lista de produtos no banco de dados
        //Só para poedermos consultar um valor de uma tabela em outra tabela
        public List<VendaHasProduto>? ProdutoList { get; set; }
    }
}
