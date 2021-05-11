using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {
        //A classe Rei extende da classe Peca.
        //A classe possui um metodo toString onde ela retorna o caracter R
        // O metodo privativo podeMover recebe a peca e diz que se a posicao da p for vazia ou a cor da peca for diferente da cor da mesma, ela pode mover.
        // O metodo booleano movimentosPossiveis instancia uma matriz boolena que possui as linhas e as colunas do tabuleiro.Sendo que a posição começa com zero.
        //Ele define a posicao da peca e verifica se ele podemover para a posicao e se a posicao é valida, caso sim, a matriz com a posicao e a coluna igual a true.Os movimentos depende de cada peça



        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString()
        {
            return "R";
        }


        private bool podeMover(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != this.cor;


        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //sudeste
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //sudoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //esquerda
            pos.definirValores(posicao.linha , posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //noroeste
            pos.definirValores(posicao.linha - 1, posicao.coluna -1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
















        }
    }
}
