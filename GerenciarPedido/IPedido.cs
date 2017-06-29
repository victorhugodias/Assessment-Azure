using GerenciarPedido.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GerenciarPedido
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IPedido" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract (Name ="PedidoSimples",Namespace = "http://localhost:52679/v1")]
    public interface IPedido_V1
    {
        [OperationContract]
        string SalvarPedido(DomainLoja.Produto produto);

        [OperationContract]
        PedidoViewModel ProximoPedido();

        [OperationContract]
        bool PedidoSalvo(int idPedido);

        [OperationContract]
        bool PedidoEnviado(int idPedido);
    }
    [ServiceContract(Name = "PedidoComposto", Namespace = ("http://localhost:52679/v2"))]
    public interface IPedido_V2
    {
        [OperationContract]
        string SalvarPedido(List<DomainLoja.Produto> ListaProdutos);

        [OperationContract]
        PedidoViewModel ProximoPedido();


        [OperationContract]
        bool PedidoSalvo(int idPedido);

        [OperationContract]
        bool PedidoEnviado(int idPedido);
    }


}
