using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Models
{
    internal class Item_previsto : Item
    {
        public int Quantidade_prevista{ get; set; }

        public Item_previsto(int quantidade, float preco_unitario, Artigo artigo,Compra compra,int quantidade_prevista) : base(quantidade, preco_unitario, artigo, compra)
        {
            Quantidade_prevista = quantidade_prevista;
        }
    }
}
