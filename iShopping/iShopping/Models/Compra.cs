using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public float Preco_total { get; set; }
        public DateTime Data_criacao { get; set; }
        public DateTime? Data_alteracao { get; set; }
        public DateTime? Data_fecho { get; set; }
        public Utilizador Utilizador { get; set; }
        public Utilizador AlteradoPor { get; set; }
        public Utilizador FechadoPor { get; set; }
        public bool Fechada { get; set; } = false;
        public List<Item_previsto> Itens { get; set; } = new List<Item_previsto>();

        public Compra() { }

        public Compra(string descricao, float preco_total, Utilizador utilizador)
        {
            Descricao = descricao;
            Preco_total = preco_total;
            Data_criacao = DateTime.Now;
            Data_alteracao = DateTime.Now;
            Utilizador = utilizador;
        }

        public void alterar_atualizacao(Utilizador utilizador)
        {
            Data_alteracao = DateTime.Now;
            AlteradoPor = utilizador;
        }

        public void fechar_compra(Utilizador utilizador)
        {
            Data_fecho = DateTime.Now;
            FechadoPor = utilizador;
        }
    }
}
