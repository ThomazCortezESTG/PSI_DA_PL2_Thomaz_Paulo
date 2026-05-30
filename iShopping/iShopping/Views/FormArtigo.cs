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
    public partial class FormArtigo : Form
    {
        private ArtigoController artigoController;
        private Artigo artigo;
        private TipoController tipoController;

        internal FormArtigo(Artigo artigoselecionado)
        {
            artigo = artigoselecionado;
            InitializeComponent();
            artigoController = new ArtigoController();
            tipoController = new TipoController();
            if (artigo == null)
            {
                btnComando.Text = "Adicionar";
            }
            else
            {
                btnComando.Text = "Editar";
                txtNome.Text = artigo.Nome;
                txtDescricao.Text = artigo.Descricao;
            }
            CarregarTipos();
        }

        private void btnComando_Click(object sender, EventArgs e)
        {
            var row = dgvTipos.SelectedRows[0];
            int id = (int)row.Cells["Id"].Value;
            string nome = txtNome.Text.Trim();
            string descricao = txtDescricao.Text.Trim();
            if (artigo != null)
            {
                string resposta = artigoController.editarArtigo(artigo.Id, nome, descricao,id);

                switch (resposta)
                {
                    case "1":
                        MessageBox.Show("Artigo não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "2":
                        MessageBox.Show("Erro ao alterar o artigo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "3":
                        MessageBox.Show("Artigo alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                }
            }
            else
            {
                string resposta = artigoController.criarArtigo(nome, descricao,id);
                switch (resposta)
                {
                    case "1":
                        MessageBox.Show("Artigo já existente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "2":
                        MessageBox.Show("Erro ao criar o artigo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "3":
                        MessageBox.Show("Artigo criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void CarregarTipos()
        {
            dgvTipos.DataSource = null;
            dgvTipos.DataSource = tipoController.getTipos();
            if (dgvTipos.Columns["Id"] != null)
                dgvTipos.Columns["Id"].Visible = false;
            if (dgvTipos.Columns["Descricao"] != null)
                dgvTipos.Columns["Descricao"].Visible = false;
            if (artigo != null)
            {
                foreach (DataGridViewRow row in dgvTipos.Rows)
                {
                    if ((int)row.Cells["Id"].Value == artigo.Tipo.Id)
                    {
                        row.Selected = true;
                        dgvTipos.CurrentCell = row.Cells["Nome"];
                        break;
                    }
                }
            }
        }
    }
}
