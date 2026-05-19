using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace iShopping.Controllers
{
    class UtilizadorController
    {
        public List<Utilizador> getUtilizadores()
        {
            using (var db = new ShoppingContext())
            {
                List<Utilizador> users = db.Utilizadores.ToList();
                return users;
            }
        }

        public bool criarUser(string username, string pass, string nome)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    bool exists = db.Utilizadores.Any(u => u.Username == username);

                    if (exists)
                        return false;

                    Utilizador newUser = new Utilizador(username, pass, nome);

                    db.Utilizadores.Add(newUser);
                    db.SaveChanges();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public string login(string username, string pass)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var user = db.Utilizadores.FirstOrDefault(u => u.Username == username && u.Password == pass);
                    if (user != null)
                        return user.Username;
                    else
                        return "";
                }
            }
            catch
            {
                return "";
            }
        }
    }
}
