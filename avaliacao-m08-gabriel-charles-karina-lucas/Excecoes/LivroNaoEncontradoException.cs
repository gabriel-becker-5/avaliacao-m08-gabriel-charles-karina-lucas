using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace avaliacao_m08_gabriel_charles_karina_lucas.Excecoes
{
    public class LivroNaoEncontradoException : Exception
    {
        public LivroNaoEncontradoException()
            : base("Livro não encontrado.") 
        {
        }
        public LivroNaoEncontradoException(int id)
            : base($"Livro com ID {id} não foi encontrado.")
        { }
    }
}
