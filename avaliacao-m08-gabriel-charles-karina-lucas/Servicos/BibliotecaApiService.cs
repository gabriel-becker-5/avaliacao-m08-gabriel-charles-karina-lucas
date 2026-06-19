using avaliacao_m08_gabriel_charles_karina_lucas.Modelos;
using avaliacao_m08_gabriel_charles_karina_lucas.Repositorios;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace avaliacao_m08_gabriel_charles_karina_lucas.Servicos
{
    
    public class BibliotecaApiService
    {
        string tituloAPI;
        string autorAPI;
        int anoAPI;
        bool ehDisponivel;
        Livro novoLivro;

        public async Task<Livro> BuscarDetalhesApiAsync(string tituloLivro)
        {
            novoLivro = null;
            var conteudoRespostaJson = "";
            try
            {
                HttpClient apiClient = new HttpClient();
                tituloLivro = tituloLivro.Replace(" ", "+");
                string URL = $"https://openlibrary.org/search.json?title={tituloLivro}";
                var resposta = await apiClient.GetAsync(URL);
                conteudoRespostaJson = await resposta.Content.ReadAsStringAsync();
                var conteudoDeserializado = JsonConvert.DeserializeObject<dynamic>(conteudoRespostaJson);
                autorAPI = (string)conteudoDeserializado["docs"]?[0]?["author_name"]?[0];
                tituloAPI = (string)conteudoDeserializado["docs"]?[0]?["title"];
                anoAPI = (int)conteudoDeserializado["docs"]?[0]?["first_publish_year"];
                ehDisponivel = true;
                novoLivro = new Livro(tituloAPI, autorAPI, anoAPI, ehDisponivel);
                Console.WriteLine($"Título: {novoLivro.Titulo} | Autor: {novoLivro.Autor} | Ano: {novoLivro.Ano} | Disponível: {(novoLivro.Disponivel ? "Sim" : "Não")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return novoLivro;
        }

        //  Grava a lista atual do repositório no arquivo JSON
        public void SalvarAcervo(RepositorioLivro repositorio)
        {
            try
            {
                // Converte a lista de livros em texto JSON formatado (bonito de ler)
                string json = JsonConvert.SerializeObject(repositorio.Livros, Formatting.Indented);

                // Grava o arquivo na pasta do projeto
                File.WriteAllText("acervo.json", json);

                Console.WriteLine("\nAcervo salvo com sucesso em acervo.json!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o acervo: {ex.Message}");
            }
        }

        //  Tenta ler o arquivo JSON e carregar os livros para a memória ao iniciar
        public void CarregarAcervoAoIniciar(RepositorioLivro repositorio)
        {
            try
            {
                // Verifica se o arquivo já existe para não dar erro na primeira execução
                if (File.Exists("acervo.json"))
                {
                    string json = File.ReadAllText("acervo.json");

                    // Converte o texto JSON de volta para uma lista de objetos Livro
                    var livrosDeserializados = JsonConvert.DeserializeObject<List<Livro>>(json);

                    if (livrosDeserializados != null)
                    {
                        repositorio.Livros = livrosDeserializados;
                        Console.WriteLine("Acervo anterior carregado com sucesso!");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum acervo anterior encontrado. Iniciando sistema vazio.");
                }
            }
            catch
            {
                Console.WriteLine("Sem arquivo anterior ou erro ao carregar.");
            }
        }
    }
}