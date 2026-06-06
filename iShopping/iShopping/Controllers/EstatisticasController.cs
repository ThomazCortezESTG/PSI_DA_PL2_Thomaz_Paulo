using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace iShopping.Controllers
{
    internal class EstatisticasController
    {
        // ── Tab 1a — Orçamento vs Total por mês ──────────────────────

        public List<ResumoMes> getResumoMeses()
        {
            using (var db = new ShoppingContext())
            {
                var orcamentos = db.Orcamentos.ToList();

                var comprasFechadas = db.Compras
                    .Where(c => c.Fechada)
                    .ToList();

                var resultado = orcamentos.Select(o =>
                {
                    float totalGasto = comprasFechadas
                        .Where(c => c.Data_fecho.HasValue
                            && c.Data_fecho.Value.Month == o.Mes
                            && c.Data_fecho.Value.Year == o.Ano)
                        .Sum(c => c.Preco_total);

                    return new ResumoMes
                    {
                        Mes = o.Mes,
                        Ano = o.Ano,
                        Orcamento = o.Montante,
                        TotalGasto = totalGasto,
                        Diferenca = o.Montante - totalGasto
                    };
                })
                .OrderByDescending(r => r.Ano)
                .ThenByDescending(r => r.Mes)
                .ToList();

                return resultado;
            }
        }

        // ── Tab 1b — Compras fechadas com percentagens ───────────────

        public List<ResumoCompra> getResumoComprasFechadas()
        {
            using (var db = new ShoppingContext())
            {
                var compras = db.Compras
                    .Include("Utilizador")
                    .Where(c => c.Fechada)
                    .ToList();

                var resultado = new List<ResumoCompra>();

                foreach (var compra in compras)
                {
                    int totalPrevistos = db.Itens
                        .OfType<Item_previsto>()
                        .Count(i => i.Compra.Id == compra.Id);

                    int totalNaoPrevistos = db.Itens
                        .OfType<Item_nao_previsto>()
                        .Count(i => i.Compra.Id == compra.Id);

                    int total = totalPrevistos + totalNaoPrevistos;

                    resultado.Add(new ResumoCompra
                    {
                        Nome = compra.Descricao,
                        DataFecho = compra.Data_fecho ?? DateTime.MinValue,
                        TotalItens = total,
                        PercPrevistos = total == 0 ? 0 : (float)totalPrevistos / total * 100,
                        PercNaoPrevistos = total == 0 ? 0 : (float)totalNaoPrevistos / total * 100
                    });
                }

                return resultado
                    .OrderByDescending(r => r.DataFecho)
                    .ToList();
            }
        }

        // ── Tab 2 — Sugestão de orçamento ────────────────────────────

        public float getSugestaoOrcamento()
        {
            using (var db = new ShoppingContext())
            {
                var orcamentos = db.Orcamentos.ToList();
                if (!orcamentos.Any()) return 0;

                return orcamentos.Average(o => o.Montante);
            }
        }

        // ── Tab 2 — Sugestão de lista de compras ─────────────────────

        public List<SugestaoItem> getSugestaoLista(int semanaAtual)
        {
            using (var db = new ShoppingContext())
            {
                // Busca compras fechadas de meses anteriores
                var comprasMesmoAno = db.Compras
                    .Where(c => c.Fechada && c.Data_fecho.HasValue)
                    .ToList()
                    // Filtra as da mesma semana do mês em meses anteriores
                    .Where(c => SemanaDoMes(c.Data_criacao) == semanaAtual
                        && !(c.Data_criacao.Month == DateTime.Now.Month
                          && c.Data_criacao.Year == DateTime.Now.Year))
                    .Select(c => c.Id)
                    .ToList();

                if (!comprasMesmoAno.Any())
                    return new List<SugestaoItem>();

                // Itens previstos dessas compras agrupados por artigo
                var itensPrevistos = db.Itens
                    .OfType<Item_previsto>()
                    .Include("Artigo")
                    .Where(i => comprasMesmoAno.Contains(i.Compra.Id))
                    .ToList();

                var itensNaoPrevistos = db.Itens
                    .OfType<Item_nao_previsto>()
                    .Include("Artigo")
                    .Where(i => comprasMesmoAno.Contains(i.Compra.Id))
                    .ToList();

                // Agrupa tudo por artigo e calcula média de quantidade
                var agrupado = itensPrevistos
                    .Select(i => new { Nome = i.Artigo?.Nome ?? "?", i.Quantidade })
                    .Concat(itensNaoPrevistos
                        .Select(i => new { Nome = i.Artigo?.Nome ?? "?", i.Quantidade }))
                    .GroupBy(i => i.Nome)
                    .Select(g => new SugestaoItem
                    {
                        NomeArtigo = g.Key,
                        QuantidadeMedia = (float)g.Average(i => i.Quantidade)
                    })
                    .OrderByDescending(s => s.QuantidadeMedia)
                    .ToList();

                return agrupado;
            }
        }

        public static int SemanaDoMes(DateTime data)
        {
            if (data.Day <= 7) return 1;
            if (data.Day <= 14) return 2;
            if (data.Day <= 21) return 3;
            return 4;
        }
    }

    // ── DTOs (classes auxiliares simples) ────────────────────────────

    public class ResumoMes
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public float Orcamento { get; set; }
        public float TotalGasto { get; set; }
        public float Diferenca { get; set; }
        public string MesAno => $"{Mes:D2}/{Ano}";
    }

    public class ResumoCompra
    {
        public string Nome { get; set; }
        public DateTime DataFecho { get; set; }
        public int TotalItens { get; set; }
        public float PercPrevistos { get; set; }
        public float PercNaoPrevistos { get; set; }
    }

    public class SugestaoItem
    {
        public string NomeArtigo { get; set; }
        public float QuantidadeMedia { get; set; }
    }
}