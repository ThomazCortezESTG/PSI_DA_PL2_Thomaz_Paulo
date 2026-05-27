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
    public partial class FormGestaoUtilizadores : FormBase
    {
        private Utilizador User;
        private UserController _controller = new UserController();
        private int selectedId = -1;

        public FormGestaoUtilizadores(Utilizador user)
        {
            InitializeComponent();
            User = user;
            labelUser.Text = $"Olá, {user.Nome}!";
            EnableDrag(panel1);
            CarregarUtilizadores();
            AtualizarBotoes();
        }

        private void CarregarUtilizadores()
        {
            dgvUtilizadores.DataSource = null;
            dgvUtilizadores.DataSource = _controller.getUtilizadores();
            if (dgvUtilizadores.Columns["Password"] != null)
                dgvUtilizadores.Columns["Password"].Visible = false;
        }

        private void AtualizarBotoes()
        {
            bool temSelecao = selectedId != -1;
            btnEditar.Enabled = temSelecao;
            btnApagar.Enabled = temSelecao;
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            selectedId = -1;
            dgvUtilizadores.ClearSelection();
            AtualizarBotoes();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Preenche todos os campos!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void dgvUtilizadores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUtilizadores.SelectedRows.Count == 0) return;

            var row = dgvUtilizadores.SelectedRows[0];
            selectedId = (int)row.Cells["Id"].Value;
            txtNome.Text = row.Cells["Nome"].Value?.ToString();
            txtUsername.Text = row.Cells["Username"].Value?.ToString();
            txtPassword.Text = "";
            AtualizarBotoes();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string resultado = _controller.criarUser(
                txtUsername.Text.Trim(),
                txtPassword.Text.Trim(),
                txtNome.Text.Trim()
            );

            if (resultado == "1")
                MessageBox.Show("Username já existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (resultado == "2")
                MessageBox.Show("Erro ao criar utilizador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Utilizador criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarUtilizadores();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string resultado = _controller.editarUser(
                selectedId,
                txtUsername.Text.Trim(),
                txtPassword.Text.Trim(),
                txtNome.Text.Trim()
            );

            if (resultado == "1")
                MessageBox.Show("Username já existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (resultado == "2")
                MessageBox.Show("Erro ao editar utilizador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Utilizador editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarUtilizadores();
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (selectedId == User.Id)
            {
                MessageBox.Show("Não podes apagar o teu próprio utilizador!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Tens a certeza que queres apagar este utilizador?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string resultado = _controller.apagarUser(selectedId);

                if (resultado == "2")
                    MessageBox.Show("Erro ao apagar utilizador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Utilizador apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarUtilizadores();
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // Navegação sidebar
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