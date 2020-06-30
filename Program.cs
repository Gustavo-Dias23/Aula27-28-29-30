using System.Collections.Generic;
using System;

namespace Aula27Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 1;
            p1.Nome = "Squier";
            p1.Preco = 4000f;

            p1.Cadastrar(p1);

            List<Produto> lista = p1.Ler();

            foreach (Produto item in lista){
                Console.WriteLine($"R$ {item.Preco} - {item.Nome}");
            }
        }
    }
}
