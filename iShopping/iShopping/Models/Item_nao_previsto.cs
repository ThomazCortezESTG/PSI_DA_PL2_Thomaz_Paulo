using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Models
{
    internal class Item_nao_previsto : Item
    {
        public string Observacoes { get; set; }

        public Item_nao_previsto() { }

        public Item_nao_previsto(int quantidade, float preco_unitario, Artigo artigo,string observacoes) : base(quantidade,preco_unitario,artigo) {
            Observacoes = observacoes;
        }
    }
}
