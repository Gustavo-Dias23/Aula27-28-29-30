using System;
using System.Collections.Generic;
using System.IO;
namespace Aula27Excel
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string PATH = "Database/produto.csv";

        public Produto(){
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }
        public void Cadastrar(Produto p){

            var linha = new string[] {PrepararLinha (p)};
            File.AppendAllLines(PATH, linha);
        }
        public List<Produto> Ler(){
            List<Produto> prod = new List<Produto>();
            string[] linhas = File.ReadAllLines(PATH);
            
            foreach(string linha in linhas){
                string[] dado = linha.Split(";");

                Produto p = new Produto();
                p.Codigo = Int32.Parse (Separar(dado[0]));
                p.Nome   = Separar(dado[1]);
                p.Preco  = float.Parse(Separar(dado[2]));

                prod.Add(p);
            }
            return prod;
        }
        /// <summary>
        /// Método que separa o símbolo de = da string do csv.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string Separar(string dado){
            return dado.Split("=")[1];
        }
        private string PrepararLinha(Produto p){
            return $"Codigo={p.Codigo};Nome={p.Nome};Preco={p.Preco}";
        }
    }
}