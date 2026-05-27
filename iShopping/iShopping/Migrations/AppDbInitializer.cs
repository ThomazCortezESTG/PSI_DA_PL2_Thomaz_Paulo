using iShopping.Models;
using System;
using System.Collections.Generic;
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


            string[,,] produtos = {
            // Frescos
            {
                {"Maçã Royal Gala", "Maçãs frescas e crocantes."},
                {"Banana da Madeira", "Bananas maduras e doces."},
                {"Tomate Chucha", "Tomates frescos para saladas e cozinhados."},
                {"Alface Frisada", "Alface fresca e estaladiça."},
                {"Peito de Frango", "Carne fresca de frango embalada."},
                {"Bife de Novilho", "Bifes tenros de novilho."},
                {"Salmão Fresco", "Postas frescas de salmão."},
                {"Pão Caseiro", "Pão tradicional acabado de cozer."},
                {"Croissant Manteiga", "Croissant fresco de manteiga."},
                {"Cenoura", "Cenouras frescas selecionadas."}
            },
            // Mercearia e Despensa
            {
                {"Arroz Agulha", "Arroz agulha de grão longo."},
                {"Massa Esparguete", "Massa de trigo duro."},
                {"Azeite Virgem Extra", "Azeite português de qualidade."},
                {"Atum em Conserva", "Atum em óleo vegetal."},
                {"Cereais Integrais", "Cereais ricos em fibra."},
                {"Café Moído", "Café torrado e moído."},
                {"Bolachas Maria", "Bolachas tradicionais."},
                {"Feijão Preto", "Feijão preto seco."},
                {"Farinha de Trigo", "Farinha para culinária e pastelaria."},
                {"Açúcar Branco", "Açúcar refinado."}
            },
            // Laticínios e Frios
            {
                {"Leite Meio Gordo", "Leite UHT meio gordo."},
                {"Iogurte Natural", "Iogurte natural sem açúcar."},
                {"Queijo Flamengo", "Queijo flamengo fatiado."},
                {"Manteiga com Sal", "Manteiga tradicional."},
                {"Fiambre da Perna Extra", "Fiambre fatiado."},
                {"Chouriço Tradicional", "Enchido tradicional português."},
                {"Queijo Fresco", "Queijo fresco pasteurizado."},
                {"Natas para Culinária", "Natas UHT para cozinhar."},
                {"Iogurte de Morango", "Iogurte líquido sabor morango."},
                {"Mortadela", "Mortadela fatiada."}
            },
            // Bebidas
            {
                {"Água Mineral", "Água mineral natural."},
                {"Sumo de Laranja", "Sumo natural de laranja."},
                {"Refrigerante Cola", "Bebida gaseificada cola."},
                {"Cerveja Lager", "Cerveja fresca tipo lager."},
                {"Vinho Tinto", "Vinho tinto português."},
                {"Vinho Branco", "Vinho branco leve."},
                {"Água com Gás", "Água gaseificada."},
                {"Whisky", "Bebida espirituosa envelhecida."},
                {"Ice Tea Pêssego", "Bebida refrescante de chá."},
                {"Néctar de Manga", "Bebida de fruta tropical."}
            },
            // Congelados
            {
                {"Ervilhas Congeladas", "Ervilhas ultracongeladas."},
                {"Pizza Congelada", "Pizza pronta a cozinhar."},
                {"Gelado de Chocolate", "Gelado cremoso de chocolate."},
                {"Douradinhos", "Filetes de peixe panados."},
                {"Batatas Pré-Fritas", "Batatas congeladas para fritar."},
                {"Hambúrguer Congelado", "Hambúrguer de novilho congelado."},
                {"Mistura de Legumes", "Legumes variados congelados."},
                {"Lasanha Congelada", "Refeição pronta ultracongelada."},
                {"Camarão Congelado", "Camarão descascado congelado."},
                {"Pescada Congelada", "Postas de pescada ultracongeladas."}
            },
            // Higiene e Beleza
            {
                {"Champô Reparador", "Champô para cabelo danificado."},
                {"Gel de Banho", "Gel de banho hidratante."},
                {"Pasta Dentífrica", "Pasta para higiene oral."},
                {"Escova de Dentes", "Escova de dentes média."},
                {"Creme Hidratante", "Creme corporal hidratante."},
                {"Desodorizante Spray", "Desodorizante de longa duração."},
                {"Sabonete Líquido", "Sabonete líquido para mãos."},
                {"Amaciador de Cabelo", "Amaciador nutritivo."},
                {"Lâminas de Barbear", "Lâminas descartáveis."},
                {"Água Micelar", "Produto de limpeza facial."}
            },
            // Limpeza e Casa
            {
                {"Detergente Roupa", "Detergente líquido para roupa."},
                {"Detergente Loiça", "Detergente manual para loiça."},
                {"Limpa Vidros", "Produto de limpeza para vidros."},
                {"Lixívia", "Desinfetante multiusos."},
                {"Sacos do Lixo", "Sacos resistentes para lixo."},
                {"Papel Higiénico", "Rolos de papel higiénico."},
                {"Rolo de Cozinha", "Papel absorvente de cozinha."},
                {"Amaciador Roupa", "Amaciador perfumado."},
                {"Esponja Multiusos", "Esponja para limpeza."},
                {"Ambientador", "Ambientador para casa."}
            },
            // Animais de Estimação
            {
                {"Ração para Cão", "Ração seca para cães adultos."},
                {"Ração para Gato", "Ração seca para gatos."},
                {"Areia para Gato", "Areia absorvente para gatos."},
                {"Comida Húmida Cão", "Patê para cães."},
                {"Comida Húmida Gato", "Patê para gatos."},
                {"Biscoitos para Cão", "Snack para cães."},
                {"Brinquedo para Gato", "Brinquedo divertido para gatos."},
                {"Coleira para Cão", "Coleira ajustável."},
                {"Shampô Animal", "Champô para cães e gatos."},
                {"Taça para Ração", "Taça resistente para alimentação."}
            },
            // Tecnologia
            {
                {"Smartphone Android", "Telemóvel com sistema Android."},
                {"Portátil 15 Polegadas", "Computador portátil para trabalho."},
                {"Rato Wireless", "Rato sem fios ergonómico."},
                {"Teclado Mecânico", "Teclado para produtividade e gaming."},
                {"Auriculares Bluetooth", "Auriculares sem fios."},
                {"Pen USB 64GB", "Dispositivo de armazenamento portátil."},
                {"Monitor 24 Polegadas", "Monitor Full HD."},
                {"Carregador USB-C", "Carregador rápido universal."},
                {"Disco SSD 1TB", "Armazenamento SSD de alta velocidade."},
                {"Smartwatch", "Relógio inteligente multifunções."}
                }
            };

            for (int i = 0; i < tipos.Length; i++) {
                context.Tipos_de_artigos.Add(new Tipo_de_artigo(tipos[i], descricoes[i]));
            }
            context.Utilizadores.Add(new Utilizador("Paulo",HashPassword("123"), "Paulo Zhang Liu"));
            base.Seed(context);

            for (int i = 0; i < produtos.GetLength(0); i++)
            {
                Tipo_de_artigo tipo = context.Tipos_de_artigos.Local.ElementAt(i);
                for (int j = 0; j < produtos.GetLength(1); j++)
                {
                    context.Artigos.Add(new Artigo(produtos[i, j, 0], produtos[i, j, 1], tipo));
                }
            }
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
