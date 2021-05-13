using tabuleiro;
namespace xadrez
{
    class PosicaoXadrez
    {
        //A classe PosicaoXadrez recebe uma coluna do tipo char e um int do tipo linha.
        // O construtor desta classe é padrao
        // O metodo mais importante de classe é o toPosicao, onde ele converte uma posicao de coluna e uma linha do tipo de xadrez para o tipo de matriz
        //A classe possui um metodo tostring para transformar a coluna e a linha em uma string

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
