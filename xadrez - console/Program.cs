using System;
using tabuleiro;
using xadrez;
namespace xadrez___console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                Tela.imprimirTabuleior(partida.tab);
                
                
                Console.ReadLine();

            }
            catch (TabuleiroException e )
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
