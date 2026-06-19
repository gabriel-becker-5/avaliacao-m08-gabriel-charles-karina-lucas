namespace avaliacao_m08_gabriel_charles_karina_lucas.Servicos
{
    public class BibliotecaApiService
    {

        private static async Task BuscarNaApiAsync()
        {
            Console.Clear();
            Console.WriteLine("--- API Open Library ---");
            Console.Write("Título: ");

            string titulo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("Inválido.");
                return;
            }

            await _repositorio.BuscarDetalhesApiAsync(titulo);
        }

        private static void SalvarAcervo()
        {
            Console.Clear();

            _repositorio.SalvarEmJson();

            Console.WriteLine("Salvo com sucesso!");
        }

        private static void CarregarAcervoAoIniciar()
        {
            try
            {
                _repositorio.CarregarDeJson();
            }
            catch
            {
                Console.WriteLine("Sem arquivo anterior.");
            }
        }
    }
}