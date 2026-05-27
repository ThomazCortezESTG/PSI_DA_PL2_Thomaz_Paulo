using iShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


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

                    string encrypt = HashPassword(pass);

                    Utilizador newUser = new Utilizador(username, encrypt, nome);

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
                    string encrypt = HashPassword(pass);
                    var user = db.Utilizadores.FirstOrDefault(u => u.Username == username && u.Password == encrypt);
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

        private string HashPassword(string password)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return String.Concat(hash
                  .ComputeHash(Encoding.UTF8.GetBytes(password))
                  .Select(item => item.ToString("x2")));
            }
        }

        public string editarUser(int id, string username, string pass, string nome)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    bool exists = db.Utilizadores.Any(u => u.Username == username && u.Id != id);
                    if (exists) return "1";

                    var user = db.Utilizadores.Find(id);
                    if (user == null) return "2";

                    user.Username = username;
                    user.Password = HashPassword(pass);
                    user.Nome = nome;
                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }

        public string apagarUser(int id)
        {
            try
            {
                using (var db = new ShoppingContext())
                {
                    var user = db.Utilizadores.Find(id);
                    if (user == null) return "2";

                    db.Utilizadores.Remove(user);
                    db.SaveChanges();
                    return "3";
                }
            }
            catch { return "2"; }
        }
    }
}
