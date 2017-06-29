using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLoja
{
    public class Pedido
    {
        [Key]

        public int idPedido { get; set; }

        public bool PedidoSalvo { get; set; }

        public bool PedidoEnviado { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
