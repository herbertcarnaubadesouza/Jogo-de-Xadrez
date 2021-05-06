using System;

namespace tabuleiro
{
    class TabuleiroException : ApplicationException
    {
        //classe criada, pertencente a classe ApplicationException, feita para mostrar erros personalizados apenas
        public TabuleiroException(string message) : base(message)
        {

        }
    }
}
