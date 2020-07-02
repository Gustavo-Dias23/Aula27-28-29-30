namespace Aula27Excel
{
    public interface iProduto
    {
         void Ler();
         void Cadastrar(Produto p);
         void Alterar(Produto _produtoAlterado);
         void Remover(string _termo);
    }
}