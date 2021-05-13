using tabuleiro;
namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)       //A classe preenche o construtor da classe Peca
        {

        }
        public override string ToString()           //A classe tem o metodo ToString que imprime T
        {
            return "T";
        }


        private bool podeMover(Posicao pos)         //O metodo pode mover confere se não tem peça ali ou se a cor for diferente(para comer ela)
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != this.cor;


        }

        public override bool[,] movimentosPossiveis()                   
        {                                                                //Uma matriz de booleana foi instanciada, com as linhas do tabuleiro e as colunas do tabuleiro
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas]; //Uma posicao é instanciada com a linha em zero e a coluna em zero
                                                                         //Assim se for acima a posicao da linha é dada como -1 e a posicao da coluna continua a mesma.
            Posicao pos = new Posicao(0, 0);                             //Enquanto a posicao for valida e poder mover a peça continua indo para frente
                                                                         //Assim a matriz com a posicao nova é retornada como true.
            //acima                                                      //Se a posicao da peca for diferente de vazio(encontrou uma peca) e encontrou uma peca da sua cor diferente, ele para.
            pos.definirValores(posicao.linha - 1, posicao.coluna);       //Se nao o valor da linha vai diminuido em 1
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            //direita
            pos.definirValores(posicao.linha , posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            return mat;
        }
    }
}
