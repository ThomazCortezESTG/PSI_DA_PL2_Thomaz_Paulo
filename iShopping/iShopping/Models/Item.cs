using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Models
{
    internal class Item
    {
        public int Id { get; set; }

        public int Quantidade{ get; set; }

        public float Preco_unitario{ get; set; }

        public Artigo Artigo { get; set; }
        public Item() { }

        public Item(int quantidade,float preco_unitario,Artigo artigo) {
            Quantidade = quantidade;
            Preco_unitario = preco_unitario;
            Artigo = artigo;
        }
    }
}
