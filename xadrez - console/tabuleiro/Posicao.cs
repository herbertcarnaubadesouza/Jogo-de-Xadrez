
namespace tabuleiro
{
    class Posicao

       //A classe Posicao possui linha e coluna.
       //A classe possui o seu construtor, onde a linha e a coluna informada são enviadas a Posicao.
       //A classe tambem possui um metodo definirValores que é a mesma coisa que o construção, só tem um nome mais intuitivo.
       //A classe possui um metodo toString onde ela imprime a "linha , coluna ".
       

    {
        public int linha;
        public int coluna;

        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;

        }
        public void definirValores(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
              
        }

        public override string ToString()
        {
            return linha.ToString() +" , "+ coluna.ToString();
        }

    }
}
