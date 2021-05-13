using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) //O construtor da classe rei apenas preenche os parametros do construtor da classe Peca
        {

        }
        public override string ToString() //A classe possui um metoto toString para retornar uma string R. 
        {
            return "R";
        }


        private bool podeMover(Posicao pos) // O metodo booleano podeMover recebe uma posicao.Assim uma peca recebe a peca que esta naquela posicao;
                                            //Assim o metodo retorna null se a peca estiver vazia ou se sua cor é diferente.
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != this.cor;


        }

        public override bool[,] movimentosPossiveis()       //O metodo movimentos possiveis é do tipo matriz booleana
                                                            // Uma matriz booleana é criada e ela possui a linha e a coluna do tabuleiro
                                                            //A posicao é instanciada na linha zero e coluna zero
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);  //Acima significa que a linha é diminuida em um e a coluna permanece igual
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))     //Se a posicao for valida ,se nao tiver peça ou se tiver peça de cor diferente
            {                                                       //A matriz de booleana é instanciada recebendo aquela linha e coluna= true;
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
