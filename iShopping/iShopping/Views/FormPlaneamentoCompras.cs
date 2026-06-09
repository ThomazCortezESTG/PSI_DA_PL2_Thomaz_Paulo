using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormPlaneamentoCompras : FormBase
    {
        private Utilizador User;
        private CompraController _controller = new CompraController();
        private OrcamentoController _controller_orcamento = new OrcamentoController();
        private int selectedId = -1;

        public FormPlaneamentoCompras(Utilizador user)
        {
            InitializeComponent();
            User = user;
            labelUser.Text = $"Olá, {user.Nome}!";
            EnableDrag(panel1);

            cmbFiltro.Items.AddRange(new string[] { "Todas", "Abertas", "Fechadas" });
            cmbFiltro.SelectedIndex = 0;

            CarregarCompras();
            AtualizarBotoes();
        }

        private void CarregarCompras()
        {
            List<Compra> compras;

            switch (cmbFiltro.SelectedIndex)
            {
                case 1:
                    compras = _controller.getComprasPorEstado(false);
                    break;
                case 2:
                    compras = _controller.getComprasPorEstado(true);
                    break;
                default:
                    compras = _controller.getTodasCompras();
                    break;
            }

            dgvCompras.DataSource = compras.Select(c => new {
                Id = c.Id,
                Nome = c.Descricao,
                Data_Criacao = c.Data_criacao,
                Fechada = c.Fechada,
                Criado_Por = c.Utilizador?.Nome ?? "",
                Total = c.Preco_total
            }).ToList();

            selectedId = -1;
            AtualizarBotoes();
        }

        private void AtualizarBotoes()
        {
            bool temSelecao = selectedId != -1;
            btnEditar.Enabled = temSelecao;
            btnApagar.Enabled = temSelecao;
            btnIniciar.Enabled = temSelecao;
            btnExportar.Enabled = temSelecao;
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCompras();
        }

        private void dgvCompras_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompras.SelectedRows.Count == 0) return;
            selectedId = (int)dgvCompras.SelectedRows[0].Cells["Id"].Value;
            AtualizarBotoes();
        }

        private void btnNovaCompra_Click(object sender, EventArgs e)
        {
            FormCompraPlaneada form = new FormCompraPlaneada(User, null,false);
            form.ShowDialog();
            CarregarCompras();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var compra = _controller.getCompraPorId(selectedId);

            FormCompraPlaneada form = new FormCompraPlaneada(User, compra, compra.Fechada);
            form.ShowDialog();
            CarregarCompras();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Tens a certeza que queres apagar esta compra?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _controller_orcamento.ReporOrcamentoDoMes(_controller.getTotalCompra(selectedId));
                string resultado = _controller.apagarCompra(selectedId);

                if (resultado == "4")
                    MessageBox.Show("Não é possível apagar uma compra fechada!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (resultado != "3")
                    MessageBox.Show("Erro ao apagar compra!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Compra apagada com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedId = -1;
                    CarregarCompras();
                    AtualizarBotoes();
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e) { Logout(); }
        private void btnInicio_Click(object sender, EventArgs e) { new FormMain(User).Show(); this.Close(); }
        private void buttonTiposArtigo_Click(object sender, EventArgs e) { new FormGestaoTiposArtigo(User).Show(); this.Close(); }
        private void btnArtigos_Click(object sender, EventArgs e) { new FormGestaoArtigos(User).Show(); this.Close(); }
        private void btnOrcamentos_Click(object sender, EventArgs e) { new FormGestaoOrcamentos(User).Show(); this.Close(); }
        private void btnCompras_Click(object sender, EventArgs e) { new FormPlaneamentoCompras(User).Show(); this.Close(); }
        private void btnEstatisticas_Click(object sender, EventArgs e) { new FormEstatisticas(User).Show(); this.Close(); }
        private void btnUtilizadores_Click(object sender, EventArgs e) { new FormGestaoUtilizadores(User).Show(); this.Close(); }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            var compra = _controller.getCompraPorId(selectedId);

            if (compra.Fechada)
            {
                MessageBox.Show("Esta compra está fechada e não pode ser editada!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_controller_orcamento.getOrcamentoDoMes(DateTime.Now.Month, DateTime.Now.Year) == null) {
                MessageBox.Show("Não existe um orçamento para este mês!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new FormModoCompra(selectedId, User).ShowDialog();
            CarregarCompras(); // atualiza lista depois de voltar
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string resposta = _controller.exportarCompraCSV(selectedId);


            switch (resposta)
            {
                case "1":
                    MessageBox.Show("Compra não encontrada.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "2":
                    MessageBox.Show("Erro ao tentar exportar!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    MessageBox.Show("Ficheiro salvado com sucesso!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "4":
                    MessageBox.Show("Não é possível exportar porque a compra ainda não está fechada!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
           
            
        }
    }
}