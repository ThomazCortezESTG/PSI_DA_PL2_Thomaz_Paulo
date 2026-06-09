using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormMain : FormBase
    {
        private Utilizador User;
        private CompraController _controller = new CompraController();
        private int selectedId = -1;
        private OrcamentoController _controller_orcamento = new OrcamentoController();

        public FormMain(Utilizador user)
        {
            InitializeComponent();
            User = user;
            EnableDrag(panel1);
            labelUser.Text = $"Olá, {user.Nome}!";
            CarregarComprasAbertas();
            AtualizarBotoes();
        }

        private void CarregarComprasAbertas()
        {
            var compras = _controller.getComprasAbertas();
            dgvComprasAbertas.DataSource = compras.Select(c => new {
                Id = c.Id,
                Nome = c.Descricao,
                Data_Criacao = c.Data_criacao,
                Criado_Por = c.Utilizador?.Nome ?? ""
            }).ToList();
        }

        private void btnNovaCompra_Click(object sender, EventArgs e)
        {
            FormPlaneamentoCompras form = new FormPlaneamentoCompras(User);
            form.Show();
            this.Close();
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
            if (_controller_orcamento.getOrcamentoDoMes(DateTime.Now.Month, DateTime.Now.Year) == null)
            {
                MessageBox.Show("Não existe um orçamento para este mês!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new FormModoCompra(selectedId, User).ShowDialog();
            CarregarComprasAbertas();
        }

        private void dgvComprasAbertas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvComprasAbertas.SelectedRows.Count == 0) return;
            selectedId = (int)dgvComprasAbertas.SelectedRows[0].Cells["Id"].Value;
            AtualizarBotoes();
        }

        private void AtualizarBotoes()
        {
            bool temSelecao = selectedId != -1;
            btnIniciar.Enabled = temSelecao;
        }
    }
}