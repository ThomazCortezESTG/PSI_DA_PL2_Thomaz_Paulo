using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
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

        public float getTotalCompra(int id)
        {
            using (var db = new ShoppingContext())
            {
                var compra = db.Compras
                    .FirstOrDefault(c => c.Id == id && !c.Fechada);

                if (compra == null)
                    return 0;

                return compra.Preco_total;
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

        public void meterPreco(int compraId, float preco) {
            using (var db = new ShoppingContext())
            {
                var compra = db.Compras.Find(compraId);
                if (compra == null) return;

                compra.Preco_total = preco;
                db.SaveChanges();
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
                    if (compra.Fechada) return "4";

                    var utilizadorDb = db.Utilizadores.Find(utilizador.Id);

                    // Calcula o total a partir dos itens guardados na BD
                    var itensPrevistos = db.Itens
                        .OfType<Item_previsto>()
                        .Where(i => i.Compra.Id == id)
                        .ToList();

                    var itensNaoPrevistos = db.Itens
                        .OfType<Item_nao_previsto>()
                        .Where(i => i.Compra.Id == id)
                        .ToList();

                    float total = 0;
                    total += itensPrevistos.Sum(i => i.Quantidade * i.Preco_unitario);
                    total += itensNaoPrevistos.Sum(i => i.Quantidade * i.Preco_unitario);

                    compra.Preco_total = total; // ← guarda o total correto
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

        // ── Exportar ─────────────────────────────────────────────────

        public string exportarCompra(int id)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var compra = db.Compras
                        .Include("Utilizador")
                        .FirstOrDefault(c => c.Id == id);
                    if (compra == null) return "1";
                    if (!compra.Fechada) return "4";

                    var itensPrevistos = db.Itens
                        .OfType<Item_previsto>()
                        .Include("Artigo")
                        .Where(i => i.Compra.Id == id)
                        .ToList();

                    var itensNaoPrevistos = db.Itens
                        .OfType<Item_nao_previsto>()
                        .Include("Artigo")
                        .Where(i => i.Compra.Id == id)
                        .ToList();

                    using (SaveFileDialog dialog = new SaveFileDialog())
                    {
                        dialog.Filter = "Text Files (*.txt)|*.txt";
                        dialog.FileName = $"recibo_compra_{id}.txt";

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            using (StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8))
                            {
                                string linha = new string('=', 48);
                                string linhafina = new string('-', 48);

                                writer.WriteLine(linha);
                                writer.WriteLine("              iSHOPPING");
                                writer.WriteLine($"          RECIBO #{compra.Id}");
                                writer.WriteLine(linha);
                                writer.WriteLine($"  Descricao : {compra.Descricao ?? "—"}");
                                writer.WriteLine($"  Utilizador: {compra.Utilizador?.Nome ?? "—"}");
                                writer.WriteLine($"  Fechada em: {compra.Data_fecho:dd/MM/yyyy HH:mm}");
                                writer.WriteLine($"  Exportado : {DateTime.Now:dd/MM/yyyy HH:mm}");
                                writer.WriteLine();

                                // Itens previstos
                                writer.WriteLine("  ITENS PREVISTOS");
                                writer.WriteLine(linhafina);
                                writer.WriteLine($"  {"#",-4} {"Artigo",-18} {"Prev",5} {"Adq",5} {"Preco",8}");
                                writer.WriteLine(linhafina);
                                if (!itensPrevistos.Any())
                                    writer.WriteLine("  Sem itens previstos.");
                                else
                                {
                                    int n = 1;
                                    foreach (var item in itensPrevistos)
                                        writer.WriteLine($"  {n++,-4} {item.Artigo?.Nome ?? "—",-18} {item.Quantidade_prevista,5} {item.Quantidade,5} {item.Preco_unitario,8:F2}");
                                }
                                writer.WriteLine(linha);
                                writer.WriteLine();
                                writer.WriteLine(linha);
                                // Itens não previstos
                                writer.WriteLine("  ITENS NAO PREVISTOS");
                                writer.WriteLine(linhafina);
                                writer.WriteLine($"  {"#",-4} {"Artigo",-18} {"Adq",5} {"Preco",8}  {"Obs",-10}");
                                writer.WriteLine(linhafina);
                                if (!itensNaoPrevistos.Any())
                                    writer.WriteLine("  Sem itens nao previstos.");
                                else
                                {
                                    int n = 1;
                                    foreach (var item in itensNaoPrevistos)
                                        writer.WriteLine($"  {n++,-4} {item.Artigo?.Nome ?? "—",-18} {item.Quantidade,5} {item.Preco_unitario,8:F2}  {item.Observacoes ?? "—",-10}");
                                }

                                writer.WriteLine();
                                writer.WriteLine(linhafina);
                                writer.WriteLine($"  Total gasto: {compra.Preco_total:F2} EUR");
                                writer.WriteLine(linha);
                                writer.WriteLine("      Gerado pelo iShopping");
                                writer.WriteLine(linha);
                            }

                            MessageBox.Show("Recibo exportado com sucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return "3";
                        }
                        return "2";
                    }
                }
            }
            catch { return "2"; }
        }
    }
}