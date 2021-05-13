
namespace tabuleiro
{
    abstract class Peca
        //A classe peca possui uma posicao(linha,coluna), um Enum cor, certa quantidade de movimentos,e ligação com o tabuleiro
        //Para instanciar uma peça tem de informar o tabuleiro e a cor da peca.Sua posicao começa com zero e a quantidade de movimentos começa com zero.
        //O metodo incrementarQtdMovimentos aumenta a quantidade de movimentos da peca em 1.
        //O metodo decrementarQtdMovimentos, diminui a quantidade de movimentos da peça em um.
        //O metodo boolenano existe movimentosPossiveis instancia uma matriz de booleano, que recebe os movimentos possiveis de cada peça, ele percorre a matriz, se retornar verdadeiro, retorna true, caso nao, retorna false
        //O metodo podeMoverPara recebe uma posicao e retorna os movimentosPossiveis de uma peça
        //O metodo abstrato booleano movimentosPossiveis ira ser utilizado pelas classes filha da classe Mãe peça(Torre,Rei,Cavalo,Bispo)
    
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca( Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = null;
            this.tabuleiro = tabuleiro;
            this.cor = cor;
            this.qtdMovimentos = 0;
        }
        public void incrementarQtdMovimenots()
        {
            this.qtdMovimentos++;
        }

        public void decrementarQtdMovimentos()
        {
            this.qtdMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podemoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis();
        
        


    }
}
