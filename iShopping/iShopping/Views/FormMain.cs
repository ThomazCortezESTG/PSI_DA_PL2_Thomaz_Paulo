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

        public FormMain(Utilizador user)
        {
            InitializeComponent();
            User = user;
            EnableDrag(panel1);
            labelUser.Text = $"Olá, {user.Nome}!";
            CarregarComprasAbertas();
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
    }
}