using DAOLoja;
using GerenciarProduto.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GerenciarProduto
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Produto" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Produto.svc ou Produto.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Produto : IProduto_V1
    {
        ProdutoD data = new ProdutoD();
        Servico.ProdutoServiceFila fila = new Servico.ProdutoServiceFila();

        public bool AdicionarNaFila(ProdutoViewModel produto)
        {
            fila.AdicionarNaFila(produto);

            return true;
        }

        public bool ProcessarFila()
        {
            fila.ProcessarFila();

            return true;

        }

        public string ListarProduto()
        {

            var retornardata = data.Produto();

            List<DomainLoja.Produto> produtos = new List<DomainLoja.Produto>();

            foreach (var item in retornardata)
            {

                produtos.Add(item);

            }

            var novo = JsonConvert.SerializeObject(produtos);

            return novo;
        }


        public bool Cadastro(DomainLoja.Produto produto)
        {

            data.AddPed(produto);
            return true;

        }

        public bool Editar(DomainLoja.Produto produto)
        {

            data.EditProd(produto);
            return true;

        }

        public bool Deletar(int idProduto)
        {

            data.DeletarProd(idProduto);
            return true;
        }
    }
}
