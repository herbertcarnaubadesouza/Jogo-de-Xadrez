
namespace tabuleiro
{
    abstract class Peca
        //A classe é abstrata e mãe da Classe Torre e Rei
        //A classe peca faz ligação com  Posicao, que possui linha e coluna.Possui relacao com a cor.Possui um atributo chamado quantidade de movimentos.E faz ligação com a classe tabuleiro
        //em seu construtor so é necessario infomar o tabuleiro e a cor, pois a posicao começa vazia, e a quantidade de movimentos começa em zero
        //A classe possui um metodo incrementar QtdMovimentos, onde a quantidade de movimentos eh somada 1
        //Por fim a classe possui um metodo abstrato relacionado aos movimentosPossiveis da peça
        
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
