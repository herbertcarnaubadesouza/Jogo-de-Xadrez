
namespace tabuleiro
{
    class Posicao

        //A classe posicao possui linha e coluna.
        //A classe possui um metodo para imprimir sua linha e sua coluna;

    {
        public int linha;
        public int coluna;

        public Posicao(int linha, int coluna)
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
