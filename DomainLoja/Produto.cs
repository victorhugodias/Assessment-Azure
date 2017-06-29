using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLoja
{
    public class Produto
    {

        //string Id/string Nome /string Categoria/string Imagem /string Preço /int Quantidade

        [Key]
        public int idProduto { get; set; }

        public string NomeProduto { get; set; }

        public string CategoriaProduto { get; set; }

        public string ImagemProduto { get; set; }

        public string PrecoProduto { get; set; }

        public int QuantidadeProduto { get; set; }

        public virtual Pedido pedido { get; set; }


    }
}
