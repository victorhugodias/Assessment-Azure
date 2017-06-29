using DomainLoja;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GerenciarProduto.Modelo
{
    public class ProdutoViewModel
    {
        [Key]
        [DataMember]
        public int idProduto { get; set; }

        [DataMember]
        public string NomeProduto { get; set; }

        [DataMember]
        public string CategoriaProduto { get; set; }

        [DataMember]
        public string ImagemProduto { get; set; }

        [DataMember]
        public string PrecoProduto { get; set; }

        [DataMember]
        public int QuantidadeProduto { get; set; }

        [DataMember]
        public string Bandeira { get; set; }

    }
}