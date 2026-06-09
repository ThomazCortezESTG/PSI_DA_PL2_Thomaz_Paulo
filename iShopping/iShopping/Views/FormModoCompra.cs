using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormModoCompra : FormBase
    {
        private Utilizador User;
        private Compra Compra;
        private float preco_total;
        private float preco_total_antigo;
        private TipoController _tipoController = new TipoController();
        private ArtigoController _artigoController = new ArtigoController();
        private CompraController _compraController = new CompraController();
        private ItemController _itemController = new ItemController();
        private List<Item_previsto> _itens = new List<Item_previsto>();
        private List<Item_nao_previsto> _itens_nao_previstos = new List<Item_nao_previsto>();
        private int selectedId = -1;
        private int form = 0; // 1 - lista dos previstos 2 - lista de nao previstos
        private OrcamentoController _orcamentoController = new OrcamentoController();
        private float _orcamentoMes = 0;
        private float disponivel = 0;
        private int CompraID;
        public FormModoCompra(int compraId, Utilizador utilizador)
        {
            InitializeComponent();
            CompraID = compraId;
            User = utilizador;
            Compra = _compraController.getCompraPorId(compraId);
            preco_total_antigo = Compra.Preco_total;
            preco_total = Compra.Preco_total;

            // Carrega orçamento do mês atual
            var orcamento = _orcamentoController.getOrcamentoDoMes(DateTime.Now.Month, DateTime.Now.Year);
            _orcamentoMes = orcamento?.Montante ?? 0;

            PreencherDados();
            CarregarTipos();
            lblTotal.Text = $"Total: {preco_total:F2}€";
            AtualizarOrcamento(); // label do orçamento
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

        private void reset() {
            cmbTipo.SelectedIndex = -1;
            cmbArtigo.DataSource = null;
            nudQuantidade.Value = 1;
            txtPreco.Text = "";
            cmb(true);
        }

        private void cmb(bool estado) {
            cmbArtigo.Enabled = estado;
            cmbTipo.Enabled = estado;
        }

        private void dgvItensPrevistos_SelectionChanged(object sender, EventArgs e)
        {
            form = 1;

            if (dgvItensPrevistos.SelectedRows.Count == 0) return;

            int index = dgvItensPrevistos.SelectedRows[0].Index;
            if (index < 0 || index >= _itens.Count) return;

            var item = _itens[index];
            nudQuantidade.Value = item.Quantidade;
            txtPreco.Text = item.Preco_unitario.ToString();
            cmbTipo.SelectedValue = item.Artigo.Tipo.Id;
            CarregarArtigosPorTipo();
            cmbArtigo.SelectedValue = item.Artigo.Id;
            cmb(false);
        }

        private void dgvItensNaoPrevistos_SelectionChanged(object sender, EventArgs e)
        {
            form = 2;

            if (dgvItensNaoPrevistos.SelectedRows.Count == 0) return;

            int index = dgvItensNaoPrevistos.SelectedRows[0].Index;
            if (index < 0 || index >= _itens_nao_previstos.Count) return;

            var item = _itens_nao_previstos[index];
            nudQuantidade.Value = item.Quantidade;
            txtPreco.Text = item.Preco_unitario.ToString();

            cmbTipo.SelectedValue = item.Artigo.Tipo.Id;
            CarregarArtigosPorTipo();
            cmbArtigo.SelectedValue = item.Artigo.Id;
            cmb(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (disponivel < 0)
            {
                MessageBox.Show("Não é possivel guardar a compra por ultrapassar o montante disponivel do orçamento!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string resposta = _itemController.guardarCompra(Compra.Id, _itens, _itens_nao_previstos);
            _compraController.fecharCompra(CompraID, User);
            
            switch (resposta) {
                case "1":
                    MessageBox.Show("Erro ao guardar compra!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "2":
                    MessageBox.Show("Erro ao guardar compra!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    break;
                case "3":
                    MessageBox.Show("Compra guardada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizarOrcamento();
                    this.Close();
                    break;
                case "4":
                    MessageBox.Show("Tem que adquirir pelo menos 1 item!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }

        private void atualizarOrcamento() {
            if (preco_total > preco_total_antigo)
            {
                float retirar = preco_total - preco_total_antigo;
                _orcamentoController.TirarOrcamentoDoMes(retirar);
            }
            else {
                float repor = preco_total_antigo - preco_total;
                _orcamentoController.ReporOrcamentoDoMes(repor);
            }
                
        }

        private void PreencherDados()
        {

            using (var db = new ShoppingContext())
            {
                _itens = _itemController.getArtigosPrevistos(Compra.Id);
                _itens_nao_previstos = _itemController.getArtigosNaoPrevistos(Compra.Id);
            }

            AtualizarGrelha();

            if (Compra.Fechada)
            {
                cmbTipo.Enabled = false;
                cmbArtigo.Enabled = false;
                nudQuantidade.Enabled = false;
                btnAdicionarItem.Enabled = false;
                btnRemoverItem.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dgvItensNaoPrevistos.SelectedRows.Count == 0) return;

            if (form != 2) {
                MessageBox.Show("Não pode apagar os artigos de uma lista previstas no modo de compra","Erro");
                return;
            }

            int index = dgvItensNaoPrevistos.SelectedRows[0].Index;
            _itens_nao_previstos.RemoveAt(index);
            AtualizarGrelha();
            cmb(true);
        }

        private void AtualizarGrelha()
        {
            float total = 0;
            // --- Itens Previstos ---
            dgvItensPrevistos.Rows.Clear();
            dgvItensPrevistos.Columns.Clear();

            dgvItensPrevistos.Columns.Add("NomeArtigo", "Artigo");
            dgvItensPrevistos.Columns.Add("Quantidade_prevista", "Quantidade Prevista");
            dgvItensPrevistos.Columns.Add("Quantidade", "Quantidade Adquirida");
            dgvItensPrevistos.Columns.Add("Preco", "Preço Unitário");
            dgvItensPrevistos.Columns.Add("Adquirido", "Adquirido");

            foreach (var item in _itens)
            {
                dgvItensPrevistos.Rows.Add(
                    item.Artigo?.Nome ?? "?",
                    item.Quantidade_prevista,
                    item.Quantidade,
                    item.Preco_unitario,
                    item.Quantidade >= item.Quantidade_prevista ? "Sim" : "Não"
                );
                total = total + item.Quantidade * item.Preco_unitario;
            }

            // --- Itens Não Previstos ---
            dgvItensNaoPrevistos.Rows.Clear();
            dgvItensNaoPrevistos.Columns.Clear();

            dgvItensNaoPrevistos.Columns.Add("NomeArtigo", "Artigo");
            dgvItensNaoPrevistos.Columns.Add("Quantidade", "Quantidade Adquirida");
            dgvItensNaoPrevistos.Columns.Add("Preco", "Preço Unitário");

            foreach (var item in _itens_nao_previstos)
            {
                dgvItensNaoPrevistos.Rows.Add(
                    item.Artigo?.Nome ?? "?",
                    item.Quantidade,
                    item.Preco_unitario
                );
                total = total + item.Quantidade * item.Preco_unitario;
            }
            preco_total = total;
            lblTotal.Text = $"Total : {preco_total}€";
            AtualizarOrcamento();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarArtigosPorTipo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            if (ver_input() != "3")
                return;

            var artigo = (Artigo)cmbArtigo.SelectedItem;

            // Verifica se já existe na lista
            if (_itens.Exists(i => i.Artigo.Id == artigo.Id) || _itens_nao_previstos.Exists(i => i.Artigo.Id == artigo.Id))
            {
                MessageBox.Show("Este artigo já foi adicionado!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _itens_nao_previstos.Add(new Item_nao_previsto((int)nudQuantidade.Value, float.Parse(txtPreco.Text), artigo, null, ""));
            AtualizarGrelha();
            reset();
            cmbTipo.SelectedIndex = -1;
            cmbArtigo.DataSource = null;
            nudQuantidade.Value = 1;
        }


        private void btnAlterarItem_Click(object sender, EventArgs e)
        {
            if (verificar_orcamento() == "Adicionar") {
                return;
            }
            if (ver_input() != "3")
                return;
            int index = dgvItensPrevistos.SelectedRows[0].Index;
            var item = _itens[index];
            item.Quantidade = (int)nudQuantidade.Value;
            item.Preco_unitario = float.Parse(txtPreco.Text);
            if (form == 1)
            {
                if (dgvItensPrevistos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleciona um item para alterar!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (form == 2)
            {
                if (dgvItensNaoPrevistos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleciona um item para alterar!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Seleciona um item para alterar!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AtualizarGrelha();
            reset();
        }

        private string ver_input() {
            if (cmbArtigo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleciona um artigo!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "1";
            }
            if (!float.TryParse(txtPreco.Text, out float novoPreco) || novoPreco <= 0)
            {
                MessageBox.Show("Preço inválido ou igual a 0!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "2";
            }

            if (nudQuantidade.Value <= 0)
            {
                MessageBox.Show("A quantidade tem de ser maior que zero!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "4";
            }
            return "3";
        }

        private string verificar_orcamento() {
            if (disponivel < 0)
            {
                DialogResult dialogResult = MessageBox.Show("Tem certeza que quer adicionar este artigo que ultrapassa do orçamento?", "Limite do orçamento ultrapasaddo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    return "Adicionar";
                }
                else
                {
                    return "";
                }
            }
            else { return ""; }
                
        }

        private void AtualizarOrcamento()
        {
            disponivel = _orcamentoMes - preco_total;
            lblOrcamento.Text = $"Orçamento disponível: {disponivel:F2}€";

            if (_orcamentoMes == 0)
            {
                lblOrcamento.Text = "Sem orçamento definido para este mês.";
                lblOrcamento.ForeColor = Color.Gray;
                return;
            }

            if (disponivel < 0)
            {
                lblOrcamento.ForeColor = Color.Red;
                lblOrcamento.Font = new Font(lblOrcamento.Font, FontStyle.Bold);
                MessageBox.Show("⚠️ Atenção: Orçamento ultrapassado!", "Orçamento Excedido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lblOrcamento.ForeColor = Color.Green;
                lblOrcamento.Font = new Font(lblOrcamento.Font, FontStyle.Regular);
            }
        }
    }
}
