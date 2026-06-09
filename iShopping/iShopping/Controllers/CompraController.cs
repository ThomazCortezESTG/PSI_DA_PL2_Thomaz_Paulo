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

        public string exportarCompraCSV(int id)
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
                        dialog.Filter = "CSV Files (*.csv)|*.csv";
                        dialog.FileName = $"compra_{id}.csv";

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            using (StreamWriter writer = new StreamWriter(dialog.FileName, false, new UTF8Encoding(true)))
                            {
                                string sep = "\t";

                                // Cabeçalho geral
                                writer.WriteLine($"Descrição{sep}Utilizador{sep}Data Fecho{sep}{sep}Total");
                                writer.WriteLine($"{compra.Descricao ?? ""}{sep}{sep}{compra.Utilizador?.Nome ?? ""}{sep}{compra.Data_fecho:dd/MM/yyyy HH:mm}{sep}{compra.Preco_total:F2} EUR");

                                writer.WriteLine();

                                // Itens previstos
                                writer.WriteLine("=== ITENS PREVISTOS ===");
                                writer.WriteLine($"Artigo{sep}{sep}{sep}Qtd Prevista{sep}Qtd Adquirida{sep}Preço Unit.{sep}Total{sep}{sep}Adquirido");
                                if (!itensPrevistos.Any())
                                    writer.WriteLine("Nenhum item previsto.");
                                else
                                    foreach (var item in itensPrevistos)
                                        writer.WriteLine($"{item.Artigo?.Nome ?? ""}{sep}{sep}{item.Quantidade_prevista}{sep}{sep}{item.Quantidade}{sep}{sep}{item.Preco_unitario:F2} EUR{sep}{item.Quantidade * item.Preco_unitario:F2} EUR{sep}{(item.Quantidade >= item.Quantidade_prevista ? "Sim" : "Não")}");

                                writer.WriteLine();

                                // Itens não previstos
                                writer.WriteLine("=== ITENS NAO PREVISTOS ===");
                                writer.WriteLine($"Artigo{sep}Qtd{sep}Preço Unit.{sep}Total{sep}Observações");
                                if (!itensNaoPrevistos.Any())
                                    writer.WriteLine("Nenhum item imprevisto foi adquirido.");
                                else
                                    foreach (var item in itensNaoPrevistos)
                                        writer.WriteLine($"{item.Artigo?.Nome ?? ""}{sep}{item.Quantidade}{sep}{item.Preco_unitario:F2} EUR{sep}{item.Quantidade * item.Preco_unitario:F2} EUR{sep}{item.Observacoes ?? "—"}");

                                writer.WriteLine();

                                // Totais
                                float totalPrevistos = itensPrevistos.Sum(i => i.Quantidade * i.Preco_unitario);
                                float totalNaoPrevistos = itensNaoPrevistos.Sum(i => i.Quantidade * i.Preco_unitario);

                                writer.WriteLine("=== RESUMO ===");
                                writer.WriteLine($"Total Previstos{sep}{sep}{totalPrevistos:F2} EUR");
                                writer.WriteLine($"Total Não Previstos{sep}{totalNaoPrevistos:F2} EUR");
                                writer.WriteLine($"Total Gasto{sep}{sep}{compra.Preco_total:F2} EUR");
                            }

                            MessageBox.Show("CSV exportado com sucesso!", "Sucesso",
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