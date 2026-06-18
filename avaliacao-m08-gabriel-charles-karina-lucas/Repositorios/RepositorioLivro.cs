using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avaliacao_m08_gabriel_charles_karina_lucas.Repositorios
{
    internal class RepositorioLivro
    {
        public List<Livro> BuscarPorAutor(string autor)
        {
            return livros
            .Where(l => l.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase))
            .ToList();
        }
    }
}
