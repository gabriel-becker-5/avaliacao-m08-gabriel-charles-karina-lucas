using avaliacao_m08_gabriel_charles_karina_lucas.Interfaces;
using avaliacao_m08_gabriel_charles_karina_lucas.Repositorios;
using System;



class Program
{

    private static IRepositorioLivro _repositorio = new RepositorioLivro();
    static async Task Main(string[] args)
    {
        CarregarAcervoAoIniciar();

        bool rodando = true;

        while (rodando)
        {
            Console.Clear();
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
                    ListarTodos();
                    break;
                case "2":
                    BuscarPorId();
                    break;
                case "3":
                    BuscarPorAutor();
                    break;
                case "4":
                    await ListarDisponiveisAsync();
                    break;
                case "5":
                    await BuscarNaApiAsync();

                    break;

                    case "6":
                    SalvarAcervo();
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

    private static void ListarTodos()
    {
        Console.Clear();

        Console.WriteLine("\n=== LISTA DE LIVROS (ORDENADOS por Título) ===");
        var livros = _repositorio.ListarTodos();
        if (livros == null ||  livros.Count == 0)

        {
            Console.WriteLine("O acervo está vazio.");


        }
        else {

            foreach (var livro in livros)
            {
                Console.WriteLine($"ID: {livro.Id} | Título: {livro.Titulo} | Autor: {livro.Autor} | Disponível: {(livro.Disponivel ? "Sim" : "Não")}");
            }
        }
        AguardarTecla();

    }

}



    