using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Controllers
{
    internal class OrcamentoController
    {
        public List<Orcamento> getOrcamentos()
        {
            using (var db = new ShoppingContext())
            {
                List<Orcamento> orcamentos = db.Orcamentos.Include("CriadoPor").ToList();
                return orcamentos;
            }
        }
        public string criarOrcamento(float montante,int mes,int ano,Utilizador user)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    Orcamento neworcameto = new Orcamento(montante,mes,ano,user);

                    db.Orcamentos.Add(neworcameto);
                    db.SaveChanges();

                    return "2";//Sucesso
                }
            }
            catch
            {
                return "1";//Erro
            }
        }

        public string editarOrcamento(int id, float montante, int mes, int ano, Utilizador user)
        {
            try
            {
                using (var db = new ShoppingContext())
                {

                    var Orcameto = db.Orcamentos.Find(id);
                    if (Orcameto == null) return "1";// Nao existe

                    Orcameto.Montante = montante;
                    Orcameto.Mes = mes;
                    Orcameto.Ano = ano;
                    Orcameto.AlteradoPor = user;
                    Orcameto.Ultima_alteracao = DateTime.Now;


                    db.SaveChanges();
                    return "3";// sucesso
                }
            }
            catch { return "2"; }// erro
        }
        public string apagarOrcamento(int id)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var orcamento = db.Orcamentos.Find(id);
                    if (orcamento == null) return "1";//N existe

                    db.Orcamentos.Remove(orcamento);
                    db.SaveChanges();
                    return "3";//Sucesso
                }
            }
            catch { return "2"; }//Erro
        }
    }
}
