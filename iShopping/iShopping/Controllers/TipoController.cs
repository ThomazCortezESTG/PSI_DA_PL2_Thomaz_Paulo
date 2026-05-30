using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Controllers
{
    internal class TipoController
    {
        public List<Tipo_de_artigo> getTipos()
        {
            using (var db = new ShoppingContext())
            {
                List<Tipo_de_artigo> tipos = db.Tipos_de_artigos.ToList();
                return tipos;
            }
        }

        public string criarTipo(string nome, string descricao)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    bool exists = db.Tipos_de_artigos.Any(u => u.Nome.ToLower() == nome.ToLower());

                    if (exists)
                        return "1";


                    Tipo_de_artigo newtipo = new Tipo_de_artigo(nome, descricao);

                    db.Tipos_de_artigos.Add(newtipo);
                    db.SaveChanges();

                    return "3";
                }
            }
            catch
            {
                return "2";
            }
        }

        public string editarTipo(int id, string nome, string descricao)
        {
            try
            {
                using (var db = new ShoppingContext())
                {

                    var tipo = db.Tipos_de_artigos.Find(id);
                    if (tipo == null) return "1";

                    tipo.Descricao = descricao;
                    tipo.Nome = nome;
                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }

        public string apagarTipo(int id)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var tipo = db.Tipos_de_artigos.Find(id);
                    if (tipo == null) return "1";

                    db.Tipos_de_artigos.Remove(tipo);
                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }

        public Tipo_de_artigo getTipoPorId(int id)
        {
            using (var db = new ShoppingContext())
            {
                return db.Tipos_de_artigos.Find(id);
            }
        }
    }
}
