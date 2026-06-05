using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping.Controllers
{
    internal class ItemController
    {
        public List<Item_previsto> getArtigosPrevistos(int id)
        {
            using (var db = new ShoppingContext())
            {

                return db.Itens.OfType<Item_previsto>().Include("Artigo").Include("Artigo.Tipo").Where(i => i.Compra.Id == id).ToList();
            }
        }

        public List<Item_nao_previsto> getArtigosNaoPrevistos(int id)
        {
            using (var db = new ShoppingContext())
            {
                return db.Itens
                    .OfType<Item_nao_previsto>()
                    .Include("Artigo")
                    .Include("Artigo.Tipo")
                    .Where(i => i.Compra.Id == id)
                    .ToList();
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

        public string guardarCompra(int compraId, List<Item_previsto> itens, List<Item_nao_previsto> itensNaoPrevistos)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    foreach (var item in itens)
                    {
                        var itemBD = db.Itens.Find(item.Id);
                        if (itemBD is Item_previsto previsto)
                        {
                            previsto.Quantidade = item.Quantidade;
                            previsto.Preco_unitario = item.Preco_unitario;
                        }
                    }

                    foreach (var item in itensNaoPrevistos)
                    {
                        if (item.Id == 0)
                        {
                            var compra = db.Compras.Find(compraId);
                            item.Compra = compra;
                            db.Itens.Add(item);
                        }
                        else
                        {
                            var itemBD = db.Itens.Find(item.Id);
                            if (itemBD is Item_nao_previsto naoPrevisto)
                            {
                                naoPrevisto.Quantidade = item.Quantidade;
                                naoPrevisto.Preco_unitario = item.Preco_unitario;
                            }
                        }
                    }

                    db.SaveChanges();
                    return "3"; // sucesso
                }
            }
            catch
            {
                return "2"; // erro
            }
        }
    }
}
