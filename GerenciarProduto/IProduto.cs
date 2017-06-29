using GerenciarProduto.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GerenciarProduto
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IProduto" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract(Name = "Produtos", Namespace = ("http://localhost:50115/v1"))]
    public interface IProduto_V1
    {
        [OperationContract]
        bool AdicionarNaFila(ProdutoViewModel produto);

        [OperationContract]
        bool ProcessarFila();

        [OperationContract]
        string ListarProduto();

        [OperationContract]
        bool Cadastro(DomainLoja.Produto produto);

        [OperationContract]
        bool Editar(DomainLoja.Produto produto);

        [OperationContract]
        bool Deletar(int idProduto);

    }
}
