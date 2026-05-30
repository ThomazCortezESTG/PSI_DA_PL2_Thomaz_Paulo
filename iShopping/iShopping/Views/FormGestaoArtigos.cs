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
    public partial class FormGestaoArtigos : FormBase
    {
        private ArtigoController _controller;
        private Utilizador User;
        private int selectedId = -1;
        public FormGestaoArtigos(Utilizador user)
        {
            InitializeComponent();
            User = user;
            EnableDrag(panel1);
            _controller = new ArtigoController();
            labelUser.Text = $"Olá, {user.Nome}!";
            CarregarArtigos();
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

        private void CarregarArtigos()
        {
            dgvArtigos.DataSource = null;
            dgvArtigos.DataSource = _controller.getArtigos();
            if (dgvArtigos.Columns["Id"] != null)
                dgvArtigos.Columns["Id"].Visible = false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Artigo artigo = null;
            FormArtigo form = new FormArtigo(artigo);
            form.ShowDialog();
            CarregarArtigos();
            AtualizarBotoes();
        }
        private void AtualizarBotoes()
        {
            bool temSelecao = selectedId != -1;
            btnEditar.Enabled = temSelecao;
            btnApagar.Enabled = temSelecao;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var row = dgvArtigos.SelectedRows[0];
            int id = (int)row.Cells["Id"].Value;
            Artigo artigo = _controller.getArtigoPorId(id);
            FormArtigo form = new FormArtigo(artigo);
            form.ShowDialog();
            selectedId = -1;
            CarregarArtigos();
            AtualizarBotoes();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Tens a certeza que queres apagar este Tipo de artigo?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string resultado = _controller.apagarArtigo(selectedId);

                if (resultado == "2")
                    MessageBox.Show("Erro ao apagar o Tipo de artigo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Tipo de artigo apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedId = -1;
                    CarregarArtigos();
                    AtualizarBotoes();
                }
            }
        }

        private void dgvArtigos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArtigos.SelectedRows.Count == 0) return;

            var row = dgvArtigos.SelectedRows[0];
            selectedId = (int)row.Cells["Id"].Value;
            AtualizarBotoes();
        }
    }
}
