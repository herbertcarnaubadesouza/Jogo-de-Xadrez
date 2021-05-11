using tabuleiro;
namespace xadrez
{
    class PosicaoXadrez
    {
        //A classe posicaoXadrez possui uma coluna char e uma linha int.Seu construtor é normal, recebe a coluna char e linha int e manda para a classe.
        //A classe possui um metodo toPosicao() onde retorna a posicao em formato de matriz
        //A classe possui um metodo to string para retornar a coluna e a linha da classe, quando executado.

        public char coluna{ get; set; }
        public int linha { get; set; }


        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }


        public Posicao toPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a');
        }


        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
