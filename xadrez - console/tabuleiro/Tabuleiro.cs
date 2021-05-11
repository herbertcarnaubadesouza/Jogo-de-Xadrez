
namespace tabuleiro
{
    class Tabuleiro
    {
        //A classe tabuleiro possui linhas e colunas e a classe tabuleiro tem uma matriz do tipo Peca.
        //O construtor da classe Tabuleiro recebe as linhas e as colunas e adiciona na matriz do tipo Peca que ela possui.
        //Como a matriz peca é privativa foram criador metodos "get" para pegar a matriz.Um deles tem a linha e as colunas como parametro, outro deles recebe apenas a posicao.
        //O metodo booleano posicaoValida verifica a posicao entre 0 e 8, caso for entre os valores, o metodo retorna true, caso não, o metodo retorna false.
        //O metodo validar Peca trata a exceção, que se o metodo posicaoValida retornar falso, ele manda uma mensagem de erro.
        //O metodo booleano existePeca valida a posicao, e retorna a peca que não for diferente de null, ou seja que exista.
        //O metodo void colocarPeca verifica se existe uma peca com o metodo existePeca, se for true, trata o erro com uma exceção.Assim a matriz do tipo pecas recebe a peca informada,e a pocicao da peca recebe a posicao informada.
        //O metodo retirar Peca do tipo Peca, se a posicao da peca for vazia, retorna null(nada).Se não,
        // uma Peca auxiliar recebe a posicao informada.A posicao da peca auxiliar é dada como null.A matriz do tipo Pecas tem sua linha e coluna dada como nulle e a variavel aux vazia é retornada


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
        public Peca retirarPeca(Posicao pos)
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
