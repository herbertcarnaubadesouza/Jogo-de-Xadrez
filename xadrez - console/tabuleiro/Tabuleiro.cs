
namespace tabuleiro
{
    class Tabuleiro
    {
        //A classe tabuleiro possui suas linhas e suas colunas.
        //A classe possui uma matriz do tipo Peca.
        //O metodo peca do tipo Peca retorna a uma peca com forme sua linha e sua coluna;
        //O metodo possui o metodo sobrescrito peca do tipo Peca que retorna uma peca com base na posicao informada;
        //O metodo posição valida verifica se a posicao informada(linha, coluna) está dentro de 0 e 8.
        //O metodo existePeca valida e posicao, e caso a posicao não esteja vazia ele retorna a peca daquela posicao.
        //O metodo validarPosicao trata o erro da posicao for maior que os parametros do tabuleiro
        //O metodo colocarPeca caso exista uma peca naquela posicao, ele retorna uma exceção.Caso o local esteja vazio, a peca é adicionada

        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

       public Tabuleiro(int linhas, int colunas)
       {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
       }


       public Peca peca(int linhas, int colunas)
        {
            return pecas[linhas, colunas];
        } 


        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }
        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))//ja vem no if como 'true', logo sinal de '!' para diferenciar
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
        public Peca retirarPeca(Posicao pos)//O metodo retirarPeca se a posicao for vazia, o metodo retorna vazio.Caso contrário uma peca auxiliar recebe aquela peça na posicao informada,e sua posicao é dada como null e a peca é esvaziada.Assim retorna a variavel auxiliar.
        {
            if(peca(pos) == null)
            {
                return null;
            }
            else
            {
                Peca aux = peca(pos);
                aux.posicao = null;
                pecas[pos.linha, pos.coluna] = null;
                return aux;
            }
        }





    }
}
