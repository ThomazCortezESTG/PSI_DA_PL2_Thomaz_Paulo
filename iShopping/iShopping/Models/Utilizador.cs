using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Models
{
    internal class Utilizador
    {
        public int Id{ get; set; }
        public string Username{ get; set; }
        public string Password{ get; set; }
        public string Nome { get; set; }

        public Utilizador() { }

        public Utilizador(string user,string pass,string nome) {
            Username = user;
            Password = pass;
            Nome = nome;
        }
    }
}
