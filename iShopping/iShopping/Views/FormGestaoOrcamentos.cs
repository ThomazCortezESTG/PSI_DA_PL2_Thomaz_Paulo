using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormGestaoOrcamentos : FormBase
    {
        private OrcamentoController _controller = new OrcamentoController();
        private Utilizador User;
        private int selectedId = -1;

        private static readonly string[] NomesMeses = {
            "", "Janeiro", "Fevereiro", "Março", "Abril",
            "Maio", "Junho", "Julho", "Agosto",
            "Setembro", "Outubro", "Novembro", "Dezembro"
        };

        public FormGestaoOrcamentos(Utilizador user)
        {
            InitializeComponent();
            User = user;
            EnableDrag(panel1);
            labelUser.Text = $"Olá, {user.Nome}!";
            AtualizarBotoes();
            CarregarOrcamentos();
        }

        private void CarregarOrcamentos()
        {
            var lista = _controller.getOrcamentos();

            dgvOrcamentos.DataSource = lista.Select(o => new {
                Id = o.Id,
                Montante = o.Montante,
                NumMes = o.Mes,                          // coluna oculta, usada na seleção
                Mes = NomesMeses[o.Mes],              // nome do mês visível na grelha
                Ano = o.Ano,
                Criado_Por = o.CriadoPor?.Nome ?? "",
                Alterado_Por = o.AlteradoPor?.Nome ?? ""
            }).ToList();

            if (dgvOrcamentos.Columns["Id"] != null) dgvOrcamentos.Columns["Id"].Visible = false;
            if (dgvOrcamentos.Columns["NumMes"] != null) dgvOrcamentos.Columns["NumMes"].Visible = false;
        }

        private void AtualizarBotoes()
        {
            bool temSelecao = selectedId != -1;
            btnEditar.Enabled = temSelecao;
            btnApagar.Enabled = temSelecao;
        }

        private void LimparCampos()
        {
            txtMontante.Text = "";
            txtAno.Text = "";
            txtMes.Text = "";
            selectedId = -1;
            dgvOrcamentos.ClearSelection();
            AtualizarBotoes();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtMontante.Text) ||
                string.IsNullOrWhiteSpace(txtAno.Text) ||
                string.IsNullOrWhiteSpace(txtMes.Text))
            {
                MessageBox.Show("Preenche todos os campos.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!float.TryParse(txtMontante.Text.Trim(), out float montante) || montante <= 0)
            {
                MessageBox.Show("O montante tem de ser um valor maior que zero.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtMes.Text.Trim(), out int mes) || mes < 1 || mes > 12)
            {
                MessageBox.Show("O mês tem de ser um número entre 1 e 12.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtAno.Text.Trim(), out int ano) || ano < 2000)
            {
                MessageBox.Show("O ano tem de ser 2000 ou superior.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            float montante = float.Parse(txtMontante.Text.Trim());
            int mes = int.Parse(txtMes.Text.Trim());
            int ano = int.Parse(txtAno.Text.Trim());

            string resposta = _controller.criarOrcamento(montante, mes, ano, User);
            switch (resposta)
            {
                case "3":
                    MessageBox.Show("Orçamento criado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarOrcamentos();
                    break;
                case "4":
                    MessageBox.Show($"Já existe um orçamento para {NomesMeses[mes]} de {ano}.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                default:
                    MessageBox.Show("Erro ao criar orçamento.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            float montante = float.Parse(txtMontante.Text.Trim());
            int mes = int.Parse(txtMes.Text.Trim());
            int ano = int.Parse(txtAno.Text.Trim());

            string resposta = _controller.editarOrcamento(selectedId, montante, mes, ano, User);
            switch (resposta)
            {
                case "3":
                    MessageBox.Show("Orçamento editado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarOrcamentos();
                    break;
                case "4":
                    MessageBox.Show($"Já existe um orçamento para {NomesMeses[mes]} de {ano}.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "1":
                    MessageBox.Show("Orçamento não encontrado.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("Erro ao editar orçamento.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Tens a certeza que queres apagar este orçamento?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string resultado = _controller.apagarOrcamento(selectedId);
            switch (resultado)
            {
                case "3":
                    MessageBox.Show("Orçamento apagado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarOrcamentos();
                    break;
                case "1":
                    MessageBox.Show("Orçamento não encontrado.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("Erro ao apagar orçamento.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvOrcamentos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrcamentos.SelectedRows.Count == 0) return;

            var row = dgvOrcamentos.SelectedRows[0];
            selectedId = (int)row.Cells["Id"].Value;
            txtMontante.Text = row.Cells["Montante"].Value?.ToString();
            txtAno.Text = row.Cells["Ano"].Value?.ToString();
            txtMes.Text = row.Cells["NumMes"].Value?.ToString(); // número, não o nome
            AtualizarBotoes();
        }

        // Navegação
        private void btnLogout_Click(object sender, EventArgs e) { Logout(); }
        private void btnInicio_Click(object sender, EventArgs e) { new FormMain(User).Show(); this.Close(); }
        private void buttonTiposArtigo_Click(object sender, EventArgs e) { new FormGestaoTiposArtigo(User).Show(); this.Close(); }
        private void btnArtigos_Click(object sender, EventArgs e) { new FormGestaoArtigos(User).Show(); this.Close(); }
        private void btnOrcamentos_Click(object sender, EventArgs e) { new FormGestaoOrcamentos(User).Show(); this.Close(); }
        private void btnCompras_Click(object sender, EventArgs e) { new FormPlaneamentoCompras(User).Show(); this.Close(); }
        private void btnEstatisticas_Click(object sender, EventArgs e) { new FormEstatisticas(User).Show(); this.Close(); }
        private void btnUtilizadores_Click(object sender, EventArgs e) { new FormGestaoUtilizadores(User).Show(); this.Close(); }
    }
}