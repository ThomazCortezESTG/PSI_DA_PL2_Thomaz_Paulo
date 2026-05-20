using iShopping.Controllers;
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
    public partial class FormRegisto : FormBase
    {
        public FormRegisto()
        {
            InitializeComponent();
        }

        private void linkRedirect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text != tbRepetirPassword.Text) { MessageBox.Show("As palavras passes não se coincidem."); }
            else {
                UserController userController = new UserController();
                string resposta = userController.criarUser(tbUsername.Text, tbPassword.Text, tbNome.Text);
                switch (resposta) {
                    case "1":
                        MessageBox.Show("User ja existe");
                        break;
                    case "2":
                        MessageBox.Show("Ocorreu um erro ao tentar criar o user..");
                        break;
                    case "3":
                        MessageBox.Show("User criado com sucesso.");
                        FormLogin formLogin = new FormLogin();
                        formLogin.Show();
                        this.Close();
                        break;
                }
            }
        }
    }
}
