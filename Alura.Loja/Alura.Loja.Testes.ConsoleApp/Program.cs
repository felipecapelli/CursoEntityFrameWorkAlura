using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var paoFrances = new Produto();
            paoFrances.Nome = "Pão Francês";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;*/

            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };


            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Felipe";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);
            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);

            using (var contexto = new LojaContext())
            {
                //-----Inicio - Mostra os comandos no banco-------------------
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());
                //-----Fim - Mostra os comandos no banco----------------------

                //--------------------------------------------------------------
                /*
                //contexto.Promocoes.Add(promocaoDePascoa);
                var promocao = contexto.Promocoes.Find(1);
                contexto.Promocoes.Remove(promocao);
                
                contexto.SaveChanges();
                ExibeEntries(contexto.ChangeTracker.Entries());
                Console.ReadLine();*/

                //--------------------------------------------------------------

                /*contexto.Compras.Add(compra);

                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();

                ExibeEntries(contexto.ChangeTracker.Entries());

                Console.ReadLine();*/
            }

        }


        /*static void Main(string[] args)
        { 
            using(var contexto = new LojaContext())
            {
                //-----Inicio - Mostra os comandos no banco-------------------
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());
                //-----Fim - Mostra os comandos no banco----------------------

                var produtos = contexto.Produtos.ToList();
                
                ExibeEntries(contexto.ChangeTracker.Entries());

                var novoProduto = new Produto()
                {
                    Nome = "Sabão em pó",
                    Categoria = "Limpeza",
                    Preco = 4.99
                };

                contexto.Produtos.Add(novoProduto);
                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.Remove(novoProduto);
                //var p1 = produtos.Last();
                //contexto.Remove(p1);
                ExibeEntries(contexto.ChangeTracker.Entries());


                //contexto.SaveChanges();

                var entry = contexto.Entry(novoProduto);
                Console.WriteLine("\n\n" + entry.Entity.ToString() + " - " + entry.State);


                //ExibeEntries(contexto.ChangeTracker.Entries());
                //--------------------------------------------------
                Console.ReadLine();
            }
        }*/

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("---------------------------");
            //foreach (var e in contexto.ChangeTracker.Entries())
            foreach (var e in entries)
            {
                //Console.WriteLine(e);
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);//Esse e.entity é a referentecia para o produto (no produto tem o To String)
            }
        }

    }
}
