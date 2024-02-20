using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("CarroId")]
        [Display(Name = "Código do carro")]
        public int ProdutoId { get; set; }

        [Column("MarcaCarro")]
        [Display(Name = "Marca do carro")]
        public string MarcaCarro { get; set;} = string.Empty;

        [Column("ModeloCarro")]
        [Display(Name = "Modelo do carro")]
        public string ModeloCarro { get; set; } = string.Empty;

        [Column("CorCarro")]
        [Display(Name = "Cor do carro")]
        public string CorCarro { get; set; } = string.Empty;

        [Column("PrecoProduto")]
        [Display(Name = "Preço do produto")]
        public double PrecoProduto { get; set; }

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        [ForeignKey("FornecedorId")]
        public int FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }

    }
}
