using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Models
{
    internal class ShoppingContext : DbContext
    {
        public DbSet<Utilizador> Clientes { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Tipo_de_artigo> Tipos_de_artigos{ get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Compra> Compras{ get; set; }
        public DbSet<Item> Itens{ get; set; }
        public DbSet<Item_previsto> Itens_previstos { get; set; }
        public DbSet<Item_nao_previsto> Itens_nao_previstos { get; set; }
    }
}
