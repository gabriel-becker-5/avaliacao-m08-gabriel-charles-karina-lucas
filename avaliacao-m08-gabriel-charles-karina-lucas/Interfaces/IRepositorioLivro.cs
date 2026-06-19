using avaliacao_m08_gabriel_charles_karina_lucas.Modelos;

namespace avaliacao_m08_gabriel_charles_karina_lucas.Interfaces
{
    public interface IRepositorioLivro
    {
        void Adicionar(Livro livro);

        Livro BuscarPorId(int id);

        List<Livro> ListarTodos();

        Livro BuscarPorAutor(string autor);
    }
}