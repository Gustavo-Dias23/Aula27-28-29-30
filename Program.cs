using System;

namespace Aula27Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 1;
            p1.Nome = "Fender";
            p1.Preco = 4500f;

            p1.Cadastrar(p1);
        }
    }
}
