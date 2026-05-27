using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Controllers
{
    internal class ArtigoController
    {
        public List<Artigo> getUtilizadores()
        {
            using (var db = new ShoppingContext())
            {
                List<Artigo> artigos = db.Artigos.Include("Tipo").ToList();
                return artigos;
            }
        }

        public string criarArtigo(string nome, string descricao, int tipo_selecionado)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    bool exists = db.Artigos.Any(u => u.Nome.ToLower() == nome.ToLower());

                    if (exists)
                        return "1";

                    Tipo_de_artigo tiposelecionado = db.Tipos_de_artigos.Where(ar => ar.Id == tipo_selecionado).Select(ar => ar).FirstOrDefault();
                    if (tiposelecionado == null)
                    {
                        return "2";
                    }


                    Artigo newArtigo = new Artigo(nome, descricao, tiposelecionado);

                    db.Artigos.Add(newArtigo);
                    db.SaveChanges();

                    return "3";
                }
            }
            catch
            {
                return "2";
            }
        }
    }
}
