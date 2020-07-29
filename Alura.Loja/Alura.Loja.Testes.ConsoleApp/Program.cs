﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("---------------------------");
            //foreach (var e in contexto.ChangeTracker.Entries())
            foreach (var e in entries)
            {
                //Console.WriteLine(e);
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);//Esse e.entity é a referentecia para o produto (no produto tem o To String)
            }
        }*/

    }
}
