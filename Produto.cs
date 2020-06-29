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
        private string PrepararLinha(Produto p){
            return $"Codigo={p.Codigo};Nome={p.Nome};Preco={p.Preco}";
        }
    }
}