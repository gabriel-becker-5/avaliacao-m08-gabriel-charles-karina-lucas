namespace avaliacao_m08_gabriel_charles_karina_lucas.Modelos
{
     public class Livro
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public int Ano { get; private set; }
        public bool Disponivel { get; private set; }

        public Livro(int id, string titulo, string autor, int ano, bool disponivel)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Disponivel = disponivel;
        }
        
        // Construtor para quando o livro vem da API Open Library
        public Livro(string titulo, string autor, int ano, bool disponivel)
        {
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Disponivel = disponivel;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"ID: {Id} | Título: {Titulo} | Autor: {Autor} | Ano: {Ano} | Disponível: {(Disponivel ? "Sim" : "Não")}");
        }
    }
}