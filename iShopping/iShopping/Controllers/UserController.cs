using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Controllers
{
    internal class UserController
    {
        public List<Utilizador> getUtilizadores()
        {
            using (var db = new ShoppingContext())
            {
                List<Utilizador> users = db.Utilizadores.ToList();
                return users;
            }
        }

        public string criarUser(string username, string pass, string nome)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    bool exists = db.Utilizadores.Any(u => u.Username == username);

                    if (exists)
                        return "1";

                    Utilizador newUser = new Utilizador(username, pass, nome);

                    db.Utilizadores.Add(newUser);
                    db.SaveChanges();

                    return "3";
                }
            }
            catch
            {
                return "2";
            }
        }

        public Utilizador login(string username, string pass)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var user = db.Utilizadores.FirstOrDefault(u => u.Username == username && u.Password == pass);
                    if (user != null)
                        return user;
                    else
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
