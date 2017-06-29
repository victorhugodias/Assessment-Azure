using DomainLoja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLoja
{
    public class PedidoD
    {

        private Data data = new Data();


        //metodo para adicionar o pedido ao bd
        public bool AddPed (Pedido pedido)
        {
            data.Pedidos.Add(pedido);
            data.SaveChanges();
            return true;
        }


        //metodo para deletar o pedido ao bd
        public bool DeletarPed (int idPedido)
        {
            Pedido pedido = data.Pedidos.Find(idPedido);

            data.Pedidos.Remove(pedido);
            data.SaveChanges();
            return true;
        }

        // metodo para editar o pedido ao bd
        public bool EditPed (Pedido pedido)
        {
            var objeto = pedidoselecionado(pedido.idPedido);

            objeto.idPedido = pedido.idPedido;

            objeto.PedidoSalvo = pedido.PedidoSalvo;

            objeto.PedidoEnviado = pedido.PedidoEnviado;

            objeto.Produtos = pedido.Produtos;

            data.SaveChanges();
            
            return true;
        }

        //metodo para usar no editped ao bd

        public Pedido pedidoselecionado (int idPedido)
        {
            var salvandoped = data.Pedidos.Where(x => x.idPedido == idPedido);

            var objetoselecionado = salvandoped.FirstOrDefault<Pedido>();


            return objetoselecionado;
        }

        public IQueryable<Pedido> Pedidos()
        {
            return data.Pedidos;
        }

    }
}
