using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace iShopping.Controllers
{
    internal class OrcamentoController
    {
        // Códigos de retorno padronizados:
        // "1" = não encontrado
        // "2" = erro
        // "3" = sucesso
        // "4" = regra de negócio (ex: já existe para esse mês)

        public List<Orcamento> getOrcamentos()
        {
            using (var db = new ShoppingContext())
            {
                return db.Orcamentos
                    .Include("CriadoPor")
                    .Include("AlteradoPor")
                    .ToList();
            }
        }

        public Orcamento getOrcamentoDoMes(int mes, int ano)
        {
            using (var db = new ShoppingContext())
            {
                return db.Orcamentos
                    .Include("CriadoPor")
                    .FirstOrDefault(o => o.Mes == mes && o.Ano == ano);
            }
        }

        public string criarOrcamento(float montante, int mes, int ano, Utilizador user)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    // Ponto 8 do enunciado: único orçamento mensal
                    bool jaExiste = db.Orcamentos.Any(o => o.Mes == mes && o.Ano == ano);
                    if (jaExiste) return "4";

                    var userDb = db.Utilizadores.Find(user.Id);
                    if (userDb == null) return "1";

                    Orcamento novoOrcamento = new Orcamento(montante, mes, ano, userDb);
                    db.Orcamentos.Add(novoOrcamento);
                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }

        public string editarOrcamento(int id, float montante, int mes, int ano, Utilizador user)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var orcamento = db.Orcamentos.Find(id);
                    if (orcamento == null) return "1";

                    // Verifica se já existe outro orçamento para o mesmo mês/ano
                    bool conflito = db.Orcamentos.Any(o => o.Mes == mes && o.Ano == ano && o.Id != id);
                    if (conflito) return "4";

                    // Carrega o user dentro do contexto para evitar problemas de tracking
                    var userDb = db.Utilizadores.Find(user.Id);
                    if (userDb == null) return "1";

                    orcamento.Montante = montante;
                    orcamento.Mes = mes;
                    orcamento.Ano = ano;
                    orcamento.AlteradoPor = userDb;
                    orcamento.Ultima_alteracao = DateTime.Now;

                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }

        public string apagarOrcamento(int id)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var orcamento = db.Orcamentos.Find(id);
                    if (orcamento == null) return "1";

                    db.Orcamentos.Remove(orcamento);
                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }
    }
}