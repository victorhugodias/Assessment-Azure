using DomainLoja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLoja
{
    public class ProdutoD
    {

        private Data data = new Data();

        public bool AddPed (Produto produto)
        {
            data.Produtos.Add(produto);
            data.SaveChanges();

            return true;

        }

        public bool DeletarProd (int idProduto)
        {
            Produto produto = data.Produtos.Find(idProduto);

            data.Produtos.Remove(produto);
            data.SaveChanges();

            return true;
        }

        public bool EditProd (Produto produto)
        {

            var objetosalvo = data.Produtos.Where(x => x.idProduto == produto.idProduto);

            var objeto = objetosalvo.FirstOrDefault<Produto>();

            objeto.idProduto = produto.idProduto;

            objeto.NomeProduto = produto.NomeProduto;

            objeto.CategoriaProduto = produto.CategoriaProduto;

            objeto.PrecoProduto = produto.PrecoProduto;

            objeto.ImagemProduto = produto.ImagemProduto;

            objeto.QuantidadeProduto = produto.QuantidadeProduto;

            data.SaveChanges();



            return true;
        }

        public Produto objetosalvo (int idProduto)
        {

            var objetosalvo = data.Produtos.Where(x => x.idProduto == idProduto);

            var objeto = objetosalvo.FirstOrDefault<Produto>();

            return objeto;
        }

        public IQueryable<Produto> Produto()
        {
            return data.Produtos.Where(y => y.pedido == null);
        }

        public bool VendaProduto(int idProduto, int quantidade)
        {
            Produto produto = data.Produtos.Find(idProduto);

            if(produto.QuantidadeProduto == 0)
            {
                return false;
            }
            else if (quantidade <= 0)
            {
                return false;
            }
            else
            {
                produto.QuantidadeProduto = produto.QuantidadeProduto - quantidade;

                data.SaveChanges();
                return true;
            }





        }






    }
}
