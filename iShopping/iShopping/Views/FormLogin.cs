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
using System.Security.Cryptography;

namespace iShopping.Views
{
    public partial class FormLogin : FormBase
    {
        ShoppingContext shoppingContext = new ShoppingContext();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void linkRedirect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegisto formRegisto = new FormRegisto();
            formRegisto.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();

            Utilizador resposta = userController.login(tbUsername.Text,tbPassword.Text);

            if (resposta == null)
            {
                MessageBox.Show("Username ou palavra-passe esta incorreto.", "Erro");
            }
            else { MessageBox.Show(resposta.Nome, "a"); }
        }
    }
}
