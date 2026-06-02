using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Models
{
    public class Orcamento
    {
        public int Id { get; set; }
        public float Montante { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public DateTime Data_criacao { get; set; }
        public DateTime Ultima_alteracao { get; set; }
        public Utilizador CriadoPor { get; set; }
        public Utilizador AlteradoPor { get; set; }

        public Orcamento() { }

        public Orcamento(float montante, int mes, int ano, Utilizador criadoPor)
        {
            Montante = montante;
            Mes = mes;
            Ano = ano;
            Data_criacao = DateTime.Now;
            Ultima_alteracao = DateTime.Now;
            CriadoPor = criadoPor;
        }

        public float ver_montante() { return Montante; }

        public void subtrair_montante(float valor)
        {
            Montante -= valor;
        }
    }
}
