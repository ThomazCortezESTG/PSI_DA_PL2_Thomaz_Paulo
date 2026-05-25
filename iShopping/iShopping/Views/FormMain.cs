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
    public partial class FormMain : FormBase
    {
        private Utilizador User;
        public FormMain(Utilizador user)
        {
            InitializeComponent();
            User = user;
            EnableDrag(panel1);
            labelUser.Text = $"Olá, {user.Nome}!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saiu da sessão com sucesso.", "Adeus!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
