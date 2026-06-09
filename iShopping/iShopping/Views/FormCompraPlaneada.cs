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
using System.Data.Entity;

namespace iShopping.Views
{
    public partial class FormCompraPlaneada : FormBase
    {
        private Utilizador User;
        private Compra Compra;
        private TipoController _tipoController = new TipoController();
        private ArtigoController _artigoController = new ArtigoController();
        private ItemController _itemController = new ItemController();
        private List<Item_previsto> _itens = new List<Item_previsto>();
        private bool Estado;
        public FormCompraPlaneada(Utilizador user, Compra compra,bool estado)
        {
            InitializeComponent();
            User = user;
            Compra = compra;
            Estado = estado;

            CarregarTipos();

            if (Compra != null)
                PreencherDados();
            else
                AtualizarBotoes(false);

        }

        private void CarregarTipos()
        {
            cmbTipo.SelectedIndexChanged -= cmbTipo_SelectedIndexChanged; // desliga evento
            cmbTipo.DisplayMember = "Nome";
            cmbTipo.ValueMember = "Id";
            cmbTipo.DataSource = _tipoController.getTipos();
            cmbTipo.SelectedIndex = -1;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged; // volta a ligar
        }

        private void CarregarArtigosPorTipo()
        {
            if (cmbTipo.SelectedIndex == -1 || cmbTipo.SelectedValue == null) return;

            int tipoId = (int)cmbTipo.SelectedValue;
            var artigos = _artigoController.getArtigosPorId(tipoId);

            cmbArtigo.DataSource = artigos;
            cmbArtigo.DisplayMember = "Nome";
            cmbArtigo.ValueMember = "Id";
            cmbArtigo.SelectedIndex = -1;
        }

        private void PreencherDados()
        {
            txtNome.Text = Compra.Descricao;

            using (var db = new ShoppingContext())
            {
                _itens = db.Itens
                    .OfType<Item_previsto>()
                    .Include("Artigo")
                    .Where(i => i.Compra.Id == Compra.Id)
                    .ToList();
            }

            AtualizarGrelha();

            if (Compra.Fechada)
            {
                txtNome.Enabled = false;
                cmbTipo.Enabled = false;
                cmbArtigo.Enabled = false;
                nudQuantidade.Enabled = false;
                btnAdicionarItem.Enabled = false;
                btnRemoverItem.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void AtualizarGrelha()
        {
            dgvItens.Rows.Clear();
            dgvItens.Columns.Clear();

            dgvItens.Columns.Add("NomeArtigo", "Artigo");
            dgvItens.Columns.Add("Quantidade_prevista", "Quantidade Prevista");

            foreach (var item in _itens)
            {
                dgvItens.Rows.Add(
                    item.Artigo?.Nome ?? "?",
                    item.Quantidade_prevista
                );
            }
        }

        private void perm_butoes(){
            if (Estado) {
                btnRemoverItem.Enabled = false;
                btnAdicionarItem.Enabled = false;
            }
        }

        private void AtualizarBotoes(bool modoLeitura)
        {
            btnRemoverItem.Enabled = !modoLeitura && dgvItens.SelectedRows.Count > 0;
            perm_butoes();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarArtigosPorTipo();
        }

        private void dgvItens_SelectionChanged(object sender, EventArgs e)
        {
            btnRemoverItem.Enabled = dgvItens.SelectedRows.Count > 0;
            perm_butoes();
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            if (cmbArtigo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleciona um artigo!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudQuantidade.Value <= 0)
            {
                MessageBox.Show("A quantidade tem de ser maior que zero!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var artigo = (Artigo)cmbArtigo.SelectedItem;

            // Verifica se já existe na lista
            if (_itens.Exists(i => i.Artigo.Id == artigo.Id))
            {
                MessageBox.Show("Este artigo já foi adicionado!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _itens.Add(new Item_previsto(0, 0, artigo, null, (int)nudQuantidade.Value));
            AtualizarGrelha();

            cmbTipo.SelectedIndex = -1;
            cmbArtigo.DataSource = null;
            nudQuantidade.Value = 1;
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count == 0) return;

            int index = dgvItens.SelectedRows[0].Index;
            _itens.RemoveAt(index);
            AtualizarGrelha();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome da compra é obrigatório!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_itens.Count == 0)
            {
                MessageBox.Show("Adiciona pelo menos um item!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string resultado;

            if (Compra == null)
                resultado = _itemController.criarCompraComItens(txtNome.Text.Trim(), User, _itens);
            else
                resultado = _itemController.editarCompraComItens(Compra.Id, txtNome.Text.Trim(), User, _itens);

            if (resultado == "3")
            {
                MessageBox.Show("Compra guardada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao guardar compra!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
