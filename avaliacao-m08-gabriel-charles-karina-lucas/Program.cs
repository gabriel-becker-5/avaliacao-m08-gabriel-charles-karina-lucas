using avaliacao_m08_gabriel_charles_karina_lucas.Excecoes;
using avaliacao_m08_gabriel_charles_karina_lucas.Repositorios;
using avaliacao_m08_gabriel_charles_karina_lucas.Modelos;
using avaliacao_m08_gabriel_charles_karina_lucas.Servicos;

class Program
{
    static async Task Main(string[] args)
    {
        BibliotecaApiService _bibliotecaApiService = new BibliotecaApiService();
        RepositorioLivro _repositorioLivro = new RepositorioLivro();

       
        _bibliotecaApiService.CarregarAcervoAoIniciar(_repositorioLivro);

        bool rodando = true;

        while (rodando)
        {
            //Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("    SISTEMA DE GERENCIAMENTO DE LIVROS  ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Listar todos os livros (Ordenados)");
            Console.WriteLine("2. Buscar por ID");
            Console.WriteLine("3. Buscar por Autor");
            Console.WriteLine("4. Listar disponíveis (Async)");
            Console.WriteLine("5. Buscar na API (Open Library)");
            Console.WriteLine("6. Salvar acervo (JSON)");
            Console.WriteLine("0. Sair");
            Console.WriteLine("========================================");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    //Console.Clear();
                    Console.WriteLine("--- Listar Todos os Livros Cadastrados ---");
                    List<Livro> livrosCadastrados = _repositorioLivro.ListarTodos();

                    if (livrosCadastrados.Count == 0)
                    {
                        Console.WriteLine("Não há livros cadastrados no momento.");
                    }
                    else
                    {
                        Console.WriteLine("\nLivros Cadastrados:");
                        foreach (Livro livro in livrosCadastrados)
                        {
                            livro.ExibirInformacoes();
                        }
                    }
                    break;

                case "2":
                    //Console.Clear();
                    Console.WriteLine("--- Buscar Livro por ID ---");
                    Console.Write("Digite o ID: ");

                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        try
                        {
                            Livro livro = _repositorioLivro.BuscarPorId(id);

                            if (livro == null)
                            {
                                throw new LivroNaoEncontradoException();
                            }

                            livro.ExibirInformacoes();
                        }
                        catch (LivroNaoEncontradoException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case "3":
                    //Console.Clear();
                    Console.WriteLine("--- Buscar Livro por Autor ---");
                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();

                    var livros = _repositorioLivro.BuscarPorAutor(autor);

                    if (livros == null || livros.Count == 0)
                    {
                        Console.WriteLine("Nenhum livro encontrado.");
                    }
                    else
                    {
                        foreach (var livro in livros)
                        {
                            livro.ExibirInformacoes();
                        }
                    }
                    break;

                case "4":
                    //Console.Clear();
                    Console.WriteLine("--- Listar Livros Disponíveis (Async) ---");
                    Console.WriteLine("Consultando disponibilidade...");
                    await _repositorioLivro.ListarDisponiveisAsync();
                    break;

                case "5":
                    //Console.Clear();
                    Console.WriteLine("--- Buscar Livro na API Open Library ---");
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(titulo))
                    {
                        Console.WriteLine("Inválido.");
                        return;
                    }

                    var Livro = await _bibliotecaApiService.BuscarDetalhesApiAsync(titulo);
                    if (Livro != null)
                    {
                        Livro novoLivro = new Livro(_repositorioLivro.QuantidadeLivrosCadastrados()+1, 
                                                    Livro.Titulo, 
                                                    Livro.Autor, 
                                                    Livro.Ano, 
                                                    Livro.Disponivel);
                        
                        _repositorioLivro.Adicionar(novoLivro);
                    }
                    break;

                case "6":
                   
                    _bibliotecaApiService.SalvarAcervo(_repositorioLivro);
                    break;

                case "0":
                    rodando = false;
                    Console.WriteLine("\nEncerrando o sistema. Até logo!");
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    break;
            }

        }
    }
}