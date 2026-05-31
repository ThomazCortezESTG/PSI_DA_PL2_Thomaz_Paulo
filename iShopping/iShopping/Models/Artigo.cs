using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Models
{
    public class Artigo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Tipo_de_artigo Tipo { get; set; }

        public Artigo() { }
        public Artigo(string nome,string descricao,Tipo_de_artigo tipo){
            Nome = nome;
            Descricao = descricao;
            Tipo = tipo;
        }
    }
}
