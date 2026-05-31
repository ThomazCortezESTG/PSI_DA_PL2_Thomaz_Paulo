using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Models
{
    public class Item_nao_previsto : Item
    {
        public string Observacoes { get; set; }

        public Item_nao_previsto() { }

        public Item_nao_previsto(int quantidade, float preco_unitario, Artigo artigo,Compra compra,string observacoes) : base(quantidade,preco_unitario,artigo,compra) {
            Observacoes = observacoes;
        }
    }
}
