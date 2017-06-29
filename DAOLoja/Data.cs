using DomainLoja;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLoja
{
    public class Data : DbContext
    {

        public Data () : base("AtAzure")
        {
            Database.SetInitializer<Data>
           (new CreateDatabaseIfNotExists<Data>());

            Database.Initialize(true);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

    }
}
