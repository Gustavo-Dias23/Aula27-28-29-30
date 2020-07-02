using System.Collections.Generic;
using System;

namespace Aula27Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 2;
            p1.Nome = "Fender";
            p1.Preco = 5500f;

            p1.Cadastrar(p1);
            //p1.Remover("Fender");

            Produto alterado = new Produto();
            alterado.Codigo = 2;
            alterado.Nome = "ESP";
            alterado.Preco = 6000f;

            p1.Alterar(alterado);

            List<Produto> lista = p1.Ler();

            foreach (Produto item in lista){
                Console.WriteLine($"R$ {item.Preco} - {item.Nome}");
            }
        }
    }
}
