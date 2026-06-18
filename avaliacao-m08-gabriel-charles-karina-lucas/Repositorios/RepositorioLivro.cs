using avaliacao_m08_gabriel_charles_karina_lucas.Modelos;

namespace avaliacao_m08_gabriel_charles_karina_lucas.Repositorios
{
    public class RepositorioLivro
    {

        public List<Livro> Livros = new List<Livro>
        {


        };

        public void Adicionar(Livro livro)
        {
            Livros.Add(livro);
        }

        public Livro BuscarPorId(int id)
        {
            Livro livroEncontrado = Livros.FirstOrDefault(l => l.Id == id);
            return livroEncontrado;
        }

        public List<Livro> ListarTodos()
        {
            List<Livro> livrosOrdenados = Livros.OrderByDescending(l => l.Titulo);
            return livrosOrdenados;
        }

        public Livro BuscarPorAutor(string autor);
        {
            var livroEncontrado = Livros.FirstOrDefault(l => l.Autor == autor);
            return livroEncontrado;
        }
    }
}