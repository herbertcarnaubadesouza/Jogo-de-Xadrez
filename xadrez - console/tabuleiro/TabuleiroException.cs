using System;

namespace tabuleiro
{
    class TabuleiroException : ApplicationException
    {
        //A classe eh do tipo ApplicationException onde tratam as exceções
        public TabuleiroException(string message) : base(message)
        {

        }
    }
}
