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
            List<Livro> livrosOrdenados = Livros.OrderByDescending(l => l.Titulo).ToList();
            return livrosOrdenados;
        }

        public List<Livro> BuscarPorAutor(string autor)
        {
            return Livros
            .Where(l => l.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase))
            .ToList();
        }

        public async Task ListarDisponiveisAsync()
        {
            await Task.Delay(500);

            List<Livro> livrosDisponiveis = Livros.Where(l => l.Disponivel == true).OrderByDescending(l => l.Titulo).ToList();

            if (livrosDisponiveis.Count == 0)
            {
                Console.WriteLine("Nenhum livro disponível no momento.");
            }
            else
            {
                Console.WriteLine("\nLivros Prontos para Empréstimo:");
                foreach (Livro livro in livrosDisponiveis)
                {
                    livro.ExibirInformacoes();
                }
            }
        }

        public int QuantidadeLivrosCadastrados()
        {
                return Livros.Count();
        }
    }
}