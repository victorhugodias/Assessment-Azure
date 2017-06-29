using DAOLoja;
using GerenciarProduto.Modelo;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciarProduto.Servico
{
    public class ProdutoServiceFila
    {
        private ProdutoD dataProduto = new ProdutoD();

        public bool AdicionarNaFila(ProdutoViewModel produto)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("filaproduto");
            queue.CreateIfNotExists();
            var json = JsonConvert.SerializeObject(produto);
            CloudQueueMessage message = new CloudQueueMessage(json);
            queue.AddMessage(message);
            return true;
        }
        public bool ProcessarFila()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("filaproduto");
            queue.CreateIfNotExists();
            var mensagem = queue.GetMessage().AsString;
            var json = JsonConvert.DeserializeObject<ProdutoViewModel>(mensagem);

            switch (json.Bandeira)
            {
                    case "Adicionar":
                    DomainLoja.Produto produto = new DomainLoja.Produto();
                    produto.idProduto = json.idProduto;
                    produto.CategoriaProduto = json.CategoriaProduto;
                    produto.ImagemProduto = json.ImagemProduto;
                    produto.NomeProduto = json.NomeProduto;
                    produto.PrecoProduto = json.PrecoProduto;
                    produto.QuantidadeProduto = json.QuantidadeProduto;
                    dataProduto.AddPed(produto);
                    break;
                    case "Remover":
                    dataProduto.DeletarProd(json.idProduto);
                    break;
                    case "Editar":
                    DomainLoja.Produto segundoprod = new DomainLoja.Produto();
                    segundoprod.idProduto = json.idProduto;
                    segundoprod.CategoriaProduto = json.CategoriaProduto;
                    segundoprod.ImagemProduto = json.ImagemProduto;
                    segundoprod.NomeProduto = json.NomeProduto;
                    segundoprod.PrecoProduto = json.PrecoProduto;
                    segundoprod.QuantidadeProduto = json.QuantidadeProduto;
                    dataProduto.EditProd(segundoprod);
                    break;
                    default:
                    return false;
            }
            return true;
        }
    }
}
