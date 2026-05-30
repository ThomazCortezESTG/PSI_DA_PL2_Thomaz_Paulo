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
    public partial class FormTipo : Form
    {
        private TipoController tipoController;
        private Tipo_de_artigo tipo;
        internal FormTipo(Tipo_de_artigo tipoSelecionado)
        {
            tipo = tipoSelecionado;
            InitializeComponent();
            tipoController = new TipoController();
            if (tipo == null) {
                btnComando.Text = "Adicionar";
            }
            else
            {
                btnComando.Text = "Editar";
                txtNome.Text = tipo.Nome;
                txtDescricao.Text = tipo.Descricao;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComando_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string descricao = txtDescricao.Text.Trim();
            if (tipo != null)
            {
                string resposta = tipoController.editarTipo(tipo.Id, nome, descricao);

                switch (resposta)
                {
                    case "1":
                        MessageBox.Show("Tipo não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "2":
                        MessageBox.Show("Erro ao alterar o Tipo de artigo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "3":
                        MessageBox.Show("Tipo de artigo alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                }
            }
            else
            {
                string resposta = tipoController.criarTipo(nome, descricao);
                switch (resposta)
                {
                    case "1":
                        MessageBox.Show("Tipo já existente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "2":
                        MessageBox.Show("Erro ao criar o Tipo de artigo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "3":
                        MessageBox.Show("Tipo de artigo criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }
    }
}
