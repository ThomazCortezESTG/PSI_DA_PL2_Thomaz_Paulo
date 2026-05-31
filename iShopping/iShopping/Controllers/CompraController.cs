using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Controllers
{
    internal class CompraController
    {
        public List<Compra> getComprasAbertas()
        {
            using (var db = new ShoppingContext())
            {
                return db.Compras
                    .Include("Utilizador")
                    .Where(c => !c.Fechada)
                    .ToList();
            }
        }

        public List<Compra> getTodasCompras()
        {
            using (var db = new ShoppingContext())
            {
                return db.Compras
                    .Include("Utilizador")
                    .ToList();
            }
        }

        public List<Compra> getComprasPorEstado(bool fechada)
        {
            using (var db = new ShoppingContext())
            {
                return db.Compras
                    .Include("Utilizador")
                    .Where(c => c.Fechada == fechada)
                    .ToList();
            }
        }

        public string criarCompra(string descricao, Utilizador utilizador)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var utilizadorDb = db.Utilizadores.Find(utilizador.Id);
                    if (utilizadorDb == null) return "2";

                    Compra novaCompra = new Compra(descricao, 0, utilizadorDb);
                    db.Compras.Add(novaCompra);
                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }

        public string editarCompra(int id, string descricao, Utilizador utilizador)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var compra = db.Compras.Find(id);
                    if (compra == null) return "1";
                    if (compra.Fechada) return "4"; // não pode editar fechada

                    var utilizadorDb = db.Utilizadores.Find(utilizador.Id);
                    compra.Descricao = descricao;
                    compra.alterar_atualizacao(utilizadorDb);
                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }

        public string fecharCompra(int id, Utilizador utilizador)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var compra = db.Compras.Find(id);
                    if (compra == null) return "1";
                    if (compra.Fechada) return "4"; // já fechada

                    var utilizadorDb = db.Utilizadores.Find(utilizador.Id);
                    compra.fechar_compra(utilizadorDb);
                    compra.Fechada = true;
                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }

        public string apagarCompra(int id)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var compra = db.Compras.FirstOrDefault(c => c.Id == id);
                    if (compra == null) return "1";
                    if (compra.Fechada) return "4";

                    var itens = db.Itens.Where(i => i.Compra.Id == id).ToList();
                    db.Itens.RemoveRange(itens);
                    db.Compras.Remove(compra);
                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }

        public Compra getCompraPorId(int id)
        {
            using (var db = new ShoppingContext())
            {
                return db.Compras
                    .Include("Utilizador")
                    .Include("Itens.Artigo")
                    .FirstOrDefault(c => c.Id == id);
            }
        }

        public string criarCompraComItens(string descricao, Utilizador utilizador, List<Item_previsto> itens)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var utilizadorDb = db.Utilizadores.Find(utilizador.Id);
                    if (utilizadorDb == null) return "2";

                    Compra novaCompra = new Compra(descricao, 0, utilizadorDb);
                    db.Compras.Add(novaCompra);
                    db.SaveChanges();

                    foreach (var item in itens)
                    {
                        var artigoDb = db.Artigos.Find(item.Artigo.Id);
                        if (artigoDb != null)
                            db.Itens.Add(new Item_previsto(0, 0, artigoDb, novaCompra, item.Quantidade_prevista));
                    }

                    db.SaveChanges();
                    return "3";
                }
            }
            catch (Exception ex)
            {
                var inner = ex;
                while (inner.InnerException != null)
                    inner = inner.InnerException;
                MessageBox.Show(inner.Message, "Erro detalhado");
                return "2";
            }
        }

        public string editarCompraComItens(int id, string descricao, Utilizador utilizador, List<Item_previsto> itens)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var compra = db.Compras.Include("Itens").FirstOrDefault(c => c.Id == id);
                    if (compra == null) return "1";
                    if (compra.Fechada) return "4";

                    var utilizadorDb = db.Utilizadores.Find(utilizador.Id);
                    compra.Descricao = descricao;
                    compra.alterar_atualizacao(utilizadorDb);

                    db.Itens.RemoveRange(compra.Itens);
                    compra.Itens.Clear();

                    foreach (var item in itens)
                    {
                        var artigoDb = db.Artigos.Find(item.Artigo.Id);
                        if (artigoDb != null)
                            compra.Itens.Add(new Item_previsto(0, 0, artigoDb, compra, item.Quantidade_prevista));
                    }

                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }
    }
}