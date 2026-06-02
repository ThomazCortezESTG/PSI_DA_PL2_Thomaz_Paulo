using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormGestaoOrcamentos : FormBase
    {
        private OrcamentoController _controller = new OrcamentoController();
        private Utilizador User;
        int selectedId = -1;
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
            dgvOrcamentos.DataSource = null;
            dgvOrcamentos.DataSource = _controller.getOrcamentos();
            if (dgvOrcamentos.Columns["Id"] != null)
                dgvOrcamentos.Columns["Id"].Visible = false;
            if (dgvOrcamentos.Columns["Ultima_alteracao"] != null)
                dgvOrcamentos.Columns["Ultima_alteracao"].Visible = false;
            if (dgvOrcamentos.Columns["AlteradoPor"] != null)
                dgvOrcamentos.Columns["AlteradoPor"].Visible = false;
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
                MessageBox.Show("Preenche todos os campos!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!float.TryParse(txtMontante.Text.Trim(), out float montante))
            {
                MessageBox.Show("Escreva o montante de forma certa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtMes.Text.Trim(), out int mes) || mes < 1 || mes > 12)
            {
                MessageBox.Show("Escreva o mes de forma certa e estar entre 1 a 12", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtAno.Text.Trim(), out int ano))
            {
                MessageBox.Show("Escreva o monstante de forma certa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void buttonTiposArtigo_Click(object sender, EventArgs e)
        {
            FormGestaoTiposArtigo form = new FormGestaoTiposArtigo(User);
            form.Show();
            this.Close();
        }

        private void btnArtigos_Click(object sender, EventArgs e)
        {
            FormGestaoArtigos form = new FormGestaoArtigos(User);
            form.Show();
            this.Close();
        }

        private void btnOrcamentos_Click(object sender, EventArgs e)
        {
            FormGestaoOrcamentos form = new FormGestaoOrcamentos(User);
            form.Show();
            this.Close();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            FormPlaneamentoCompras form = new FormPlaneamentoCompras(User);
            form.Show();
            this.Close();
        }

        private void btnEstatisticas_Click(object sender, EventArgs e)
        {
            FormEstatisticas form = new FormEstatisticas(User);
            form.Show();
            this.Close();
        }

        private void btnUtilizadores_Click(object sender, EventArgs e)
        {
            FormGestaoUtilizadores form = new FormGestaoUtilizadores(User);
            form.Show();
            this.Close();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FormMain form = new FormMain(User);
            form.Show();
            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) 
            {
                return;
            }

            float montante = float.Parse(txtMontante.Text);
            int mes = int.Parse(txtMes.Text);
            int ano = int.Parse(txtAno.Text);

            string resposta = _controller.criarOrcamento(montante,mes,ano,User);
            switch (resposta) 
            {
                case "1":
                    MessageBox.Show("Erro ao criar orçamento!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "2":
                    MessageBox.Show("Orçamento criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            LimparCampos();
            CarregarOrcamentos();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtMontante.Clear();
            txtMes.Clear();
            txtAno.Clear();
        }

        private void dgvOrcamentos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrcamentos.SelectedRows.Count == 0) return;

            var row = dgvOrcamentos.SelectedRows[0];
            selectedId = (int)row.Cells["Id"].Value;
            txtMontante.Text = row.Cells["Montante"].Value?.ToString();
            txtAno.Text = row.Cells["Ano"].Value?.ToString();
            txtMes.Text = row.Cells["Mes"].Value?.ToString();
            AtualizarBotoes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            float montante = float.Parse(txtMontante.Text);
            int mes = int.Parse(txtMes.Text);
            int ano = int.Parse(txtAno.Text);

            string resposta = _controller.editarOrcamento(selectedId,montante, mes, ano, User);
            switch (resposta)
            {
                case "1":
                    MessageBox.Show("Erro ao criar orçamento!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "2":
                    MessageBox.Show("Orçamento criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            LimparCampos();
            CarregarOrcamentos();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {

            var confirm = MessageBox.Show("Tens a certeza que queres apagar este Orcçamento?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string resultado = _controller.apagarOrcamento(selectedId);

                if (resultado == "2")
                    MessageBox.Show("Erro ao apagar o orçamento!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Orçamento apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarOrcamentos();
                }
            }
        }
    }
}
