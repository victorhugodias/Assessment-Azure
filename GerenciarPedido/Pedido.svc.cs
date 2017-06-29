using DAOLoja;
using DomainLoja;
using GerenciarPedido.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GerenciarPedido
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Pedido" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Pedido.svc ou Pedido.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Pedido : IPedido_V1, IPedido_V2
    {
        private PedidoD data = new PedidoD();
        private Servico.ServicePedidoFila fila = new Servico.ServicePedidoFila();


        public string SalvarPedido(DomainLoja.Produto produto)
        {

            Servico.ServicePedidoFila fila = new Servico.ServicePedidoFila();

            Produto objeto = new Produto();
            objeto.idProduto = produto.idProduto;
            objeto.QuantidadeProduto = produto.QuantidadeProduto;

            List<Produto> ListaProdutos = new List<Produto>();

            ListaProdutos.Add(objeto);

            DomainLoja.Pedido objetopedido = new DomainLoja.Pedido();
            objetopedido.Produtos = ListaProdutos;
            objetopedido.PedidoSalvo = false;
            objetopedido.PedidoEnviado = false;



            var res = data.AddPed(objetopedido);

            if (res.ToString() == "True")
            {
                fila.AdicionarPedidoAFila(objetopedido.idPedido);
                return "Pedido realizado.";

            }
            else
            {
                return "Error!";
            }

        }




        public string SalvarPedido(List<DomainLoja.Produto> ListaProdutos)
        {
            List<Produto> ProdutosLista = new List<Produto>();

            foreach (var item in ListaProdutos)
            {
                Produto produto = new Produto();
                produto.idProduto = item.idProduto;
                produto.NomeProduto = item.NomeProduto;
                produto.QuantidadeProduto = item.QuantidadeProduto;

                ProdutosLista.Add(produto);

            }

            DomainLoja.Pedido objetoPedido = new DomainLoja.Pedido();
            objetoPedido.Produtos = ProdutosLista;
            objetoPedido.PedidoSalvo = false;
            objetoPedido.PedidoEnviado = false;

            var res = data.AddPed(objetoPedido);

            if (res.ToString() == "True")
            {
                fila.AdicionarPedidoAFila(objetoPedido.idPedido);
                return "Pedido realizado!";
            }
            else
            {
                return "Erro!";
            }




        }
        public PedidoViewModel ProximoPedido()
        {

            PedidoViewModel pedido = new PedidoViewModel();

            pedido = fila.PegarProximoPedido();



            return pedido;



        }

        public bool PedidoSalvo(int idPedido)
        {

            var pedido = data.pedidoselecionado(idPedido);

            pedido.PedidoSalvo = true;

            data.EditPed(pedido);

            return true;
        }

        public bool PedidoEnviado(int idPedido)
        {

            var pedido = data.pedidoselecionado(idPedido);

            pedido.PedidoSalvo = true;

            data.EditPed(pedido);
            return true;
        }

    }
}
