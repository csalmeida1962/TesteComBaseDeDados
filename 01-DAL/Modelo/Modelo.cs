using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web.Script.Serialization;


namespace Modelo
{

    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "A descrição do produto é de preenchimento obrigatório")]
        [DisplayName("Descrição do Produto")]
        public string Descricao { get; set; }

        public byte[] Imagem { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório")]
        [DisplayName("Preço Venda")]
        [DataType(DataType.Currency)]
        public Decimal PrVenda { get; set; }

        [ForeignKey("SubCategoria")]
        [DisplayName("Sub.Categoria")]
        public int IdSubCategoria { get; set; }

        [ScriptIgnore]
        public virtual SubCategoria SubCategoria { get; set; }


    }

    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        [DisplayName("Descrição da Categoria")]
        public string Descricao { get; set; }

        public byte[] Imagem { get; set; }

        [ScriptIgnore]
        public virtual IEnumerable<SubCategoria> SubCategorias { get; set; }
    }

    [Table("SubCategorias")]
    public class SubCategoria
    {
        [Key]
        public int IdSubCategoria { get; set; }

        [Required(ErrorMessage = "A Categoria é de preenchimento obrigatório")]
        [DisplayName("Descrição da Sub.Categoria")]
        public string Descricao { get; set; }

        [ForeignKey("Categoria")]
        [DisplayName("Categoria")]
        public int IdCategoria { get; set; }

        [ScriptIgnore]
        public virtual Categoria Categoria { get; set; }

        [ScriptIgnore]
        public virtual IEnumerable<Produto> Produtos { get; set; }

    }


}
