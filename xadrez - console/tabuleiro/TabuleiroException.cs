using System;

namespace tabuleiro
{
    class TabuleiroException : ApplicationException
    {
        //A classe é do tipo ApplicationException onde ela foi criada para tratar as exceções do código.
        public TabuleiroException(string message) : base(message)
        {

        }
    }
}
