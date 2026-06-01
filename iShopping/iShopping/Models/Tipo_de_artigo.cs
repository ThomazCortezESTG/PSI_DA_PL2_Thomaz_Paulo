using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Models
{
    public class Tipo_de_artigo
    {
        public int Id { get; set; }

        public string Nome{ get; set; }

        public string Descricao{ get; set; }

        public Tipo_de_artigo() { }
        public Tipo_de_artigo(string nome,string descricao) {
            Nome = nome;
            Descricao = descricao;
        }

        public override string ToString() {
            return Nome;
        }
    }
}
