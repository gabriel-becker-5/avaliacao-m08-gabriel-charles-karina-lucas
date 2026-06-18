using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avaliacao_m08_gabriel_charles_karina_lucas.Modelos
{
     public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public bool Disponivel { get; set; }

        public Livro(int id, string titulo, string autor, int ano, bool disponivel)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Disponivel = disponivel;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Ano: {Ano}");
            Console.WriteLine($"Disponível: {(Disponivel ? "Sim" : "Não")}");
        }

    }
}
