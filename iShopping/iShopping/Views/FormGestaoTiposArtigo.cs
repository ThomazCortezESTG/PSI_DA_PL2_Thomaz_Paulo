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
    public partial class FormGestaoTiposArtigo : FormBase
    {
        private TipoController _controller;
        private Utilizador User;
        private int selectedId = -1;

        public FormGestaoTiposArtigo(Utilizador user)
        {
            InitializeComponent();
            User = user;
            EnableDrag(panel1);
            _controller = new TipoController();
            labelUser.Text = $"Olá, {user.Nome}!";
            CarregarTipos();
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
            Tipo_de_artigo tipo = null;
            FormTipo form = new FormTipo(tipo);
            form.ShowDialog();
            CarregarTipos();
            AtualizarBotoes();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Tens a certeza que queres apagar este Tipo de artigo?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string resultado = _controller.apagarTipo(selectedId);

                if (resultado == "2")
                    MessageBox.Show("Erro ao apagar o Tipo de artigo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Tipo de artigo apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedId = -1;
                    CarregarTipos();
                    AtualizarBotoes();
                }
            }
        }
        private void CarregarTipos()
        {
            dgvTipos.DataSource = null;
            dgvTipos.DataSource = _controller.getTipos(); 
            if (dgvTipos.Columns["Id"] != null)
                dgvTipos.Columns["Id"].Visible = false;
        }

        private void dgvTipos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTipos.SelectedRows.Count == 0) return;

            var row = dgvTipos.SelectedRows[0];
            selectedId = (int)row.Cells["Id"].Value;
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
            var row = dgvTipos.SelectedRows[0];
            int id = (int)row.Cells["Id"].Value;
            Tipo_de_artigo tipo = _controller.getTipoPorId(id);
            FormTipo form = new FormTipo(tipo);
            form.ShowDialog();
            selectedId = -1;
            CarregarTipos();
            AtualizarBotoes();
        }
    }
}
