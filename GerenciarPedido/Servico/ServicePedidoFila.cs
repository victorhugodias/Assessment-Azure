using DAOLoja;
using GerenciarPedido.Modelo;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciarPedido.Servico
{
    public class ServicePedidoFila
    {


        private ProdutoD dataProduto = new ProdutoD();
        private PedidoD dabaPedido = new PedidoD();

        public bool AdicionarPedidoAFila(int idPedido)
        {

           
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("filapedido");
            queue.CreateIfNotExists();
            var objeto = dabaPedido.pedidoselecionado(idPedido);
            var json = JsonConvert.SerializeObject(objeto);
            CloudQueueMessage message = new CloudQueueMessage(json);
            queue.AddMessage(message);
            return true;
        }

        public PedidoViewModel PegarProximoPedido()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("filapedido");
            queue.CreateIfNotExists();
            CloudQueueMessage peekedMessage = queue.GetMessage();
            
            var ProximoPedido = JsonConvert.DeserializeObject<PedidoViewModel>(peekedMessage.AsString);
            queue.DeleteMessage(peekedMessage);



            return ProximoPedido;
        }

    }
}