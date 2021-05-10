
namespace tabuleiro
{
    abstract class Peca
    //toda peca tem uma Posicao(linha,coluna), uma Cor, uma certa quantidade de movimentos, E esta associada com um tabuleiro;
    //ela possui um metodo para incrementar certa quantidade de Movimentos
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

        public abstract bool[,] movimentosPossiveis();
        
        


    }
}
