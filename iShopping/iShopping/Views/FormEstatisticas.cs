using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormEstatisticas : FormBase
    {
        private Utilizador User;
        private EstatisticasController _controller = new EstatisticasController();

        public FormEstatisticas(Utilizador user)
        {
            InitializeComponent();
            User = user;
            EnableDrag(panel1);
            labelUser.Text = $"Olá, {user.Nome}!";

            // Mostra a semana atual na label
            int semana = EstatisticasController.SemanaDoMes(DateTime.Now);
            lblSemanaAtual.Text = $"Semana atual do mês: {semana}ª semana";

            CarregarOrcamentoMes();
            CarregarComprasFechadas();
        }

        // ── Tab 1a — Orçamento vs Total por mês ──────────────────────

        private void CarregarOrcamentoMes()
        {
            dgvOrcamentoMes.Rows.Clear();
            dgvOrcamentoMes.Columns.Clear();

            dgvOrcamentoMes.Columns.Add("MesAno", "Mês/Ano");
            dgvOrcamentoMes.Columns.Add("Orcamento", "Orçamento (€)");
            dgvOrcamentoMes.Columns.Add("TotalGasto", "Total Gasto (€)");
            dgvOrcamentoMes.Columns.Add("Diferenca", "Diferença (€)");
            dgvOrcamentoMes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var dados = _controller.getResumoMeses();

            foreach (var linha in dados)
            {
                int row = dgvOrcamentoMes.Rows.Add(
                    linha.MesAno,
                    $"{linha.Orcamento:F2}",
                    $"{linha.TotalGasto:F2}",
                    $"{linha.Diferenca:F2}"
                );

                // Pinta a linha a vermelho se gastou mais do que o orçamento
                if (linha.Diferenca < 0)
                {
                    dgvOrcamentoMes.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                    dgvOrcamentoMes.Rows[row].DefaultCellStyle.Font =
                        new Font(dgvOrcamentoMes.Font, FontStyle.Bold);
                }
                else
                {
                    dgvOrcamentoMes.Rows[row].DefaultCellStyle.ForeColor = Color.Green;
                }
            }

            if (dados.Count == 0)
                dgvOrcamentoMes.Rows.Add("—", "—", "—", "Sem dados");
        }

        // ── Tab 1b — Compras fechadas com percentagens ───────────────

        private void CarregarComprasFechadas()
        {
            dgvComprasFechadas.Rows.Clear();
            dgvComprasFechadas.Columns.Clear();

            dgvComprasFechadas.Columns.Add("Nome", "Compra");
            dgvComprasFechadas.Columns.Add("DataFecho", "Data Fecho");
            dgvComprasFechadas.Columns.Add("TotalItens", "Total Itens");
            dgvComprasFechadas.Columns.Add("PercPrevistos", "% Previstos");
            dgvComprasFechadas.Columns.Add("PercNaoPrevistos", "% Não Previstos");
            dgvComprasFechadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var dados = _controller.getResumoComprasFechadas();

            foreach (var linha in dados)
            {
                dgvComprasFechadas.Rows.Add(
                    linha.Nome,
                    linha.DataFecho.ToString("dd/MM/yyyy HH:mm"),
                    linha.TotalItens,
                    $"{linha.PercPrevistos:F1}%",
                    $"{linha.PercNaoPrevistos:F1}%"
                );
            }

            if (dados.Count == 0)
                dgvComprasFechadas.Rows.Add("—", "—", "—", "—", "Sem compras fechadas");
        }

        // ── Tab 2 — Sugestão de orçamento ────────────────────────────

        private void btnGerarOrcamento_Click(object sender, EventArgs e)
        {
            float sugestao = _controller.getSugestaoOrcamento();

            if (sugestao == 0)
            {
                lblResultadoOrcamento.Text = "Sem orçamentos anteriores para calcular sugestão.";
                lblResultadoOrcamento.ForeColor = Color.Gray;
                return;
            }

            // Pega o próximo mês
            DateTime proximo = DateTime.Now.AddMonths(1);
            lblResultadoOrcamento.Text =
                $"Sugestão para {proximo:MMMM yyyy}: {sugestao:F2}€";
            lblResultadoOrcamento.ForeColor = Color.Blue;
            lblResultadoOrcamento.Font =
                new Font(lblResultadoOrcamento.Font, FontStyle.Bold);
        }

        // ── Tab 2 — Sugestão de lista de compras ─────────────────────

        private void btnGerarLista_Click(object sender, EventArgs e)
        {
            int semana = EstatisticasController.SemanaDoMes(DateTime.Now);
            var dados = _controller.getSugestaoLista(semana);

            dgvSugestaoLista.Rows.Clear();
            dgvSugestaoLista.Columns.Clear();

            dgvSugestaoLista.Columns.Add("Artigo", "Artigo");
            dgvSugestaoLista.Columns.Add("QuantidadeMedia", "Qtd. Média");
            dgvSugestaoLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dados.Count == 0)
            {
                dgvSugestaoLista.Rows.Add("—", "Sem dados de semanas anteriores.");
                return;
            }

            foreach (var item in dados)
            {
                dgvSugestaoLista.Rows.Add(
                    item.NomeArtigo,
                    $"{item.QuantidadeMedia:F1}"
                );
            }
        }

        // ── Navegação ─────────────────────────────────────────────────

        private void btnInicio_Click(object sender, EventArgs e)
        { new FormMain(User).Show(); this.Close(); }

        private void buttonTiposArtigo_Click(object sender, EventArgs e)
        { new FormGestaoTiposArtigo(User).Show(); this.Close(); }

        private void btnArtigos_Click(object sender, EventArgs e)
        { new FormGestaoArtigos(User).Show(); this.Close(); }

        private void btnOrcamentos_Click(object sender, EventArgs e)
        { new FormGestaoOrcamentos(User).Show(); this.Close(); }

        private void btnCompras_Click(object sender, EventArgs e)
        { new FormPlaneamentoCompras(User).Show(); this.Close(); }

        private void btnEstatisticas_Click(object sender, EventArgs e)
        { new FormEstatisticas(User).Show(); this.Close(); }

        private void btnUtilizadores_Click(object sender, EventArgs e)
        { new FormGestaoUtilizadores(User).Show(); this.Close(); }

        private void btnLogout_Click(object sender, EventArgs e)
        { Logout(); }
    }
}