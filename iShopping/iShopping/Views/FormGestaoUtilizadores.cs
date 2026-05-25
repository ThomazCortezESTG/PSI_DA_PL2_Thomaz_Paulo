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
    public partial class FormGestaoUtilizadores : FormBase
    {
        private Utilizador User;
        public FormGestaoUtilizadores(Utilizador user)
        {
            InitializeComponent();
            User = user;
            labelUser.Text = $"Olá, {user.Nome}!";
            EnableDrag(panel1);
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
    }
}
