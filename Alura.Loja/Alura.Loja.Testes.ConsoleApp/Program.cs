using Microsoft.EntityFrameworkCore;
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
            /*
            using (var contexto = new LojaContext())
            {
                
                //-----Inicio - Mostra os comandos no banco-------------------
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());
                //-----Fim - Mostra os comandos no banco----------------------


                var promocao = new Promocao();
                promocao.Descricao = "Queima Total Janeiro 2017";
                promocao.DataInicio = new DateTime(2017, 1, 1);
                promocao.DataTermino = new DateTime(2017, 1, 31);

                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Bebidas")
                    .ToList();

                foreach(var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                contexto.Promocoes.Add(promocao);
                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();
            }*/

            /*using (var contexto2 = new LojaContext())
            {
                //-----Inicio - Mostra os comandos no banco-------------------
                var serviceProvider = contexto2.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());
                //-----Fim - Mostra os comandos no banco----------------------

                //var promocao = contexto2
                //    .Promocoes
                //    .Include("Produtos.Produto")
                //    .FirstOrDefault();


                var promocao = contexto2
                    .Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();
                Console.WriteLine("\nMostrando os produtos da promoção...");
                foreach(var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }*/

            using (var contexto = new LojaContext())
            {
                //-----Inicio - Mostra os comandos no banco-------------------
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());
                //-----Fim - Mostra os comandos no banco----------------------

                var cliente = contexto
                    .Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Endereço de entrega: {cliente.EnderecoDeEntrega.Logradouro}");
                

                //Pegar as compras com valor maior que 10 para um produto especifico
                var produto = contexto
                    .Produtos
                    .Include(p => p.Compras)
                    .ThenInclude(c => c.Produto)
                    .Where(p=> p.Id == 4002)
                    .FirstOrDefault();

                contexto.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Preco > 10)
                    .Load();

                Console.WriteLine("Mostrando as compras do produto");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item);
                }
            }
            
            
            Console.ReadLine();
}

            /*
            static void Main(string[] args)
            {
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de tal";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua dos Inválidos",
                Complemento = "sobrado",
                Bairro = "Centro",
                Cidade = "Cidade"
            };

            using (var contexto = new LojaContext())
            {
                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
            }
            */

            /*
                static void Main(string[] args)
                {
                    //--------------------------------------------------------------
                    var paoFrances = new Produto();
                    paoFrances.Nome = "Pão Francês";
                    paoFrances.PrecoUnitario = 0.40;
                    paoFrances.Unidade = "Unidade";
                    paoFrances.Categoria = "Padaria";

                    var compra = new Compra();
                    compra.Quantidade = 6;
                    compra.Produto = paoFrances;
                    compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;
                    //--------------------------------------------------------------

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

                        //contexto.Promocoes.Add(promocaoDePascoa);
                        var promocao = contexto.Promocoes.Find(1);
                        contexto.Promocoes.Remove(promocao);

                        contexto.SaveChanges();
                        ExibeEntries(contexto.ChangeTracker.Entries());
                        Console.ReadLine();

                        //--------------------------------------------------------------

                        contexto.Compras.Add(compra);

                        ExibeEntries(contexto.ChangeTracker.Entries());

                        contexto.SaveChanges();

                        ExibeEntries(contexto.ChangeTracker.Entries());

                        Console.ReadLine();
                }*/


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
