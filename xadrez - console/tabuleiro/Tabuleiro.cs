
namespace tabuleiro
{
    class Tabuleiro
    {
        //A classe tabuleiro possui linhas, colunas e esta ligada com a classe Peca;
        //como o atributo Peca[,] pecas eh privado, o unico jeito de acessar ele é pelo método Peca peca, que retorna o proprio atributo Peca
        //A classe possui o atributo sobrescrito Peca peca, que retorna o atributo pecas mas apenas escrevendo a posicao.
        // A classe possui uma logica de validação que começa com        ||posição valida --> validar posicao -->existepeca||
        //A classe possui um metodo retirar Peca, que verifica em um dos caminhos se a posição for vazia, retornando nada,e  o outro, que armazena a posição da Peca em uma variavel, declara a 
        //Posicao dela como vazia de duas formas e retorna a pec aux;

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
