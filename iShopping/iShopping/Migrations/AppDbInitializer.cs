using iShopping.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace iShopping.Migrations
{

    internal sealed class AppDbInitializer : DropCreateDatabaseIfModelChanges<ShoppingContext>
    {

        protected override void Seed(iShopping.Models.ShoppingContext context)
        {
            string[] tipos = {"Alimentação Fresca", "Mercearia e Despensa", "Laticínios e Frios", "Bebidas", "Congelados", 
                "Higiene e Beleza", "Limpeza e Casa", "Animais de Estimação", "Tecnologia" };

            string[] descricoes = {"Frutas, legumes, verduras, talho (carnes), peixaria e padaria/pastelaria.", 
                "Alimentos não perecíveis como arroz, massa, azeite, conservas, cereais, café e bolachas.",
                "Leite, iogurtes, queijos, manteigas e charcutaria.",
                "Águas, sumos, refrigerantes, vinhos, cervejas e bebidas espirituosas.",
                "Legumes, refeições pré-feitas, gelados e peixe/carne ultracongelados.",
                "Champôs, géis de banho, cremes e produtos de higiene oral.",
                "Detergentes para a roupa, loiça e limpa-tudo, além de sacos do lixo e papel.",
                "Ração (seca e húmida) e areia para gatos ou cães.",
                "Dispositivos eletronicos"};

            for (int i = 0; i < tipos.Length; i++) {
                context.Tipos_de_artigos.Add(new Tipo_de_artigo(tipos[i], descricoes[i]));
            }
            context.Utilizadores.Add(new Utilizador("Paulo",HashPassword("123"), "Paulo Zhang Liu"));
            base.Seed(context);
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
    }
}
