using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        /// <summary>
        /// Método para cadastrar produtos.
        /// </summary>
        /// <param name="p"></param>
        public void Cadastrar(Produto p){

            var linha = new string[] {PrepararLinha (p)};
            File.AppendAllLines(PATH, linha);
        }
        /// <summary>
        /// Método para ler a lista de produtos no csv.
        /// </summary>
        /// <returns></returns>
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
            prod = prod.OrderBy(z =>z.Nome).ToList();

            return prod;
        }
        /// <summary>
        /// Altera um produto.
        /// </summary>
        public void Alterar(Produto _produtoAlterado){
            List<string>  linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH)){
                string linha;
                while((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha);
                }
            }
            linhas.RemoveAll(z => z.Split(";")[0].Split("=")[1] == _produtoAlterado.Codigo.ToString());

            linhas.Add( PrepararLinha(_produtoAlterado) );

            using(StreamWriter output = new StreamWriter(PATH)){
                foreach(string ln in linhas){
                    output.Write(ln + "\n");
                }
            }

        }
    
        public List<Produto> Filtrar(string _nome){
            return Ler().FindAll(x=> x.Nome == _nome);
        }
        /// <summary>
        /// Método pra remover linhas do csv.
        /// </summary>
        /// <param name="_termo"></param>
        public void Remover(string _termo){
            //Lista criada para fazer uma espécie de backup na memória do sistema.
            List<string> linhas = new List<string>();
            using(StreamReader arquivo = new StreamReader(PATH)){
                string linha;
                while((linha = arquivo.ReadLine()) !=null){
                    linhas.Add(linha);
                }
                linhas.RemoveAll(z => z.Contains(_termo)); 
            }
            
            using(StreamWriter output = new StreamWriter(PATH)){
                output.Write(String.Join(Environment.NewLine, linhas.ToArray()));
            }
        }
        /// <summary>
        /// Método que separa o símbolo de = da string do csv.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string Separar(string dado){
            return dado.Split("=")[1];
        }
        /// <summary>
        /// Método para arrumar as linhas no console.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string PrepararLinha(Produto p){
            return $"Codigo={p.Codigo};Nome={p.Nome};Preco={p.Preco}";
        }
    }
}