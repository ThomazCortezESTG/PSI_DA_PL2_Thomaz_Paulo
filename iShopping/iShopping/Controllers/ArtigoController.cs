using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Controllers
{
    internal class ArtigoController
    {
        public List<Artigo> getArtigos()
        {
            using (var db = new ShoppingContext())
            {
                List<Artigo> artigos = db.Artigos.Include("Tipo").ToList();
                return artigos;
            }
        }

        public List<Artigo> getArtigosPorId(int id)
        {
            using (var db = new ShoppingContext())
            {
                List<Artigo> artigos = db.Artigos.Include("Tipo").ToList().FindAll(a => a.Tipo.Id == id);
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
                        return "1"; // Ja existe

                    Tipo_de_artigo tiposelecionado = db.Tipos_de_artigos.Where(ar => ar.Id == tipo_selecionado).Select(ar => ar).FirstOrDefault();
                    if (tiposelecionado == null)
                    {
                        return "2";
                    }


                    Artigo newArtigo = new Artigo(nome, descricao, tiposelecionado);

                    db.Artigos.Add(newArtigo);
                    db.SaveChanges();

                    return "3";// sucesso
                }
            }
            catch
            {
                return "2";
            }
        }
        public string editarArtigo(int id, string nome, string descricao,int tipo_selecionado)
        {
            try
            {
                using (var db = new ShoppingContext())
                {

                    var Artigo = db.Artigos.Find(id);
                    if (Artigo == null) return "1";// Nao existe

                    Tipo_de_artigo tiposelecionado = db.Tipos_de_artigos.Where(ar => ar.Id == tipo_selecionado).Select(ar => ar).FirstOrDefault();
                    if (tiposelecionado == null)
                    {
                        return "2";
                    }

                    Artigo.Descricao = descricao;
                    Artigo.Nome = nome;
                    Artigo.Tipo = tiposelecionado;

                    db.SaveChanges();
                    return "3";// sucesso
                }
            }
            catch { return "2"; }// erro
        }

        public string apagarArtigo(int id)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var artigo = db.Artigos.Find(id);
                    if (artigo == null) return "1";// Nao existe

                    db.Artigos.Remove(artigo);
                    db.SaveChanges();
                    return "3"; // sucesso
                }
            }
            catch { return "2"; } // erro
        }

        public Artigo getArtigoPorId(int id)
        {
            using (var db = new ShoppingContext())
            {
                return db.Artigos.Include("Tipo").FirstOrDefault(a => a.Id == id);
            }
        }
    }
}
