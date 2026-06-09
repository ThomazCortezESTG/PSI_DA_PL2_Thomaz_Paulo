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
    public partial class FormArtigo : FormBase
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

        private void CarregarTipos()
        {
            cmbTipo.SelectedIndexChanged -= cmbTipo_SelectedIndexChanged; // desliga evento
            cmbTipo.DisplayMember = "Nome";
            cmbTipo.ValueMember = "Id";
            cmbTipo.DataSource = tipoController.getTipos();
            cmbTipo.SelectedIndex = -1;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged; // volta a ligar
        }

        private void btnComando_Click(object sender, EventArgs e)
        {
            if(cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleciona um artigo!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string nome = txtNome.Text.Trim();
            string descricao = txtDescricao.Text.Trim();
            var tipo = (Tipo_de_artigo)cmbTipo.SelectedItem;
            if (artigo != null)
            {
                string resposta = artigoController.editarArtigo(artigo.Id, nome, descricao,tipo);

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
                string resposta = artigoController.criarArtigo(nome, descricao, tipo);
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

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
