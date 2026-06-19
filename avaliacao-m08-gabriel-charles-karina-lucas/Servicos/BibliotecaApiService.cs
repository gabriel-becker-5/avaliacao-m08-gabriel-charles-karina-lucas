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

        private static void SalvarAcervo()
        {
            //_repositorio.SalvarEmJson();
            Console.WriteLine("Salvo com sucesso!");
        }

        private static void CarregarAcervoAoIniciar()
        {
            try
            {
                //_repositorio.CarregarDeJson();
            }
            catch
            {
                Console.WriteLine("Sem arquivo anterior.");
            }
        }
    }
}