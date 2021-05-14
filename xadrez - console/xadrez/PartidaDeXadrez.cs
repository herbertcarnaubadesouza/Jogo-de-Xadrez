using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    class PartidaDeXadrez
    {
        //A classe PartidaDeXadrez possui um tabuleiro, um turno, um jogador atual do tipo Cor, booelana para verificar se a partida fi terminada, um conjunto de pecas e pecascapturadas, e uma booleana de xeque
        //

        public Tabuleiro tab { get; private set; }

        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }



        public PartidaDeXadrez()//O tabuleiro é instanciado nesta classe, onde ele possui 8 linhas e 8 colunas.O turno começa em 1, o jogadorAtual começa na Cor Branca.Boolena terminada e xeque começam em false.
                                //o conjunto de pecas e capturadas são instanciadas, assim como o metodo auxiliar colocarPecas() é instanciado no construtor.
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();

            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)// O metodo executa movimento recebe uma posicao de origem e uma posicao de destino
                                                                    // Uma peca p recebe uma peca retirada da origem.
                                                                    // A peca p é aumentada sua quantidade de movimentos em um.
                                                                    // pecaCapturada do tipo Peca recebe a peca que tiver na posicao de destino
                                                                    //A peca p que vinha da origem foi colocada na posicao de destino
                                                                    //Se a peca captrada for diferente de null(Tiver uma peça a posicao de destino), a pecaCapturada é adicionada na coleção de capturadas.
                                                                    //se nao a pecaCapturada é retornada vazia mesmo.
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimenots();
            Peca pecaCaputarada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCaputarada != null)
            {
                capturadas.Add(pecaCaputarada);//Aqui a peca capturada é adicionada ao conjunto das pecasCapturadas
            }

            //#jogadaespecial roque pequeno
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemT = new Posicao(origem.linha , origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Peca T = tab.retirarPeca(origemT);
                T.incrementarQtdMovimenots();
                tab.colocarPeca(T, destinoT);


            }

            //#jogadaespecial roque grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                Peca T = tab.retirarPeca(origemT);
                T.incrementarQtdMovimenots();
                tab.colocarPeca(T, destinoT);


            }



            return pecaCaputarada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)//O metodo void desfazMovimento recebe a posicao de origem, a posicao de destino e a peca capturada
                                                                                       //A peca p recebe uma peca retirada da posicao destino, e a peca p diminui a qtdDeMovimentos da peça em um
                                                                                       //Assim se a pecaCapturada informada for diferente de vazio(se existia uma peça), a peca é colocada novamente na posicao destino, e é removida do conjunto das capturadas
                                                                                       //Assim a peca p é colocada na posição de origem novamente.

        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQtdMovimentos();
            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);

            //#jogadaespecial roque pequeno
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Peca T = tab.retirarPeca(destinoT);
                T.decrementarQtdMovimentos();
                tab.colocarPeca(T, origemT);
            }

            //#jogadaespecial roque grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                Peca T = tab.retirarPeca(destinoT);
                T.decrementarQtdMovimentos();
                tab.colocarPeca(T, origemT);
            }

        }


        public void realizaJogada(Posicao origem, Posicao destino)//O metodo realizaJogada recebe uma posicao de origem e uma posicao de destino
                                                                  //Uma pecaCapturada executa um movimento da origem para o desitino
                                                                  //Se o jogadorAtual esta em xeque o movimento é desfeito
                                                                  //Se o jogador adversario esta em xeque o xeque é permitido
                                                                  //Se nao for nenhuma dessas o xeque permanece falso
                                                                  //Ao fim disto o turno é aumentado e o jogador é mudado.
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            if (testeXequemate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                mudaJogador();
            }


            

        }

        public void validarPosicaoDeOrigem(Posicao pos)//O metodo validar posicao de origem recebe uma posicao
                                                        //Caso não haja uma peça naquela posição, uma mensagem de exceção é enviada
                                                        //Caso a posicao que foi escolhida possui uma cor diferente da do jogadorAtual, uma mensagem de exceção é enviada
                                                        //Caso nao exista movimentos possiveis para aquela peça, uma exceção é enviada
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)  //se a peca na posicao de origem nao conseguir se mover para a posicao de destino, caso de ja falso, uma mensagem de exceção é enviada
        {
            if (!tab.peca(origem).movimentoPosissivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }




        private void mudaJogador() //O metodo muda jogador , caso o jogadoratual for branca, ele muda para preta.Da mesma forma,se for preta a cor do jogadoratual vira branca.
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }



        public HashSet<Peca> pecasCapturadas(Cor cor) //O metodo pecasCapturadas é do tipo do conjunto Peca
                                                      //Uma variavel auxiliar do tipo conjunto de Peca foi instanciada
                                                      //Assim se dentro do conjuntos das capturadas se a peca for da mesma cor ela é adicionada ao conjunto das pecasCapturadas daquela cor


        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca item in capturadas)
            {
                if (item.cor == cor)
                {
                    aux.Add(item);
                }
            }
            return aux;
        }

        private Cor adversaria(Cor cor)//Este metodo verifica a cor, caso a cor for igual branca, a diversaria será a preta, e assim vice e versa
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor)//Este método auxiliar retorna a peça rei com base na cor fornecida
                                 //Se rodar no foreach da colecao de pecas encontrar um rei, ele retorna o rei
        {
            foreach (Peca item in pecasEmJogo(cor))
            {
                if(item is Rei)
                {
                    return item;
                }
            }
            return null;
        }


        public HashSet<Peca>pecasEmJogo(Cor cor) //O metodo pecasEmJogo recebe uma cor
                                                 // Um conjunto do tipo Peca auxiliar foi instanciado
                                                 // Um foreach circula entre um conjunto das capturadas
                                                 //se a cor da peça capturada for igual a cor fornecida, a peca é adicionada ao conjunto das capturadas
                                                 //Caso a cor seja diferente das cores das peças capturadas, as pecasCapturadas daquela cor serão removidas
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca item in pecas)
            {
                if (item.cor == cor)
                {
                    aux.Add(item);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));//Esse comando sgnifica remover uma coleção
            return aux;
        }

        public bool estaEmXeque(Cor cor)        //O metodo booleano estaEmXeque recebe uma cor
                                                // Uma peca recebe um rei da cor recebida, caso não receba(impossivel), uma mensagem de exceção é enviada
                                                //Se existir movimentos possiveis, a peça está em xeque, se não ela retorna false.
                                                
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro");
            }

            foreach (Peca item in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = item.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testeXequemate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca item in pecasEmJogo(cor))
            {
                bool[,] mat = item.movimentosPossiveis();
                for (int i = 0; i < tab.linhas; i++)
                {
                    for (int j = 0; j < tab.colunas; j++)
                    {
                        if (mat[i,j])
                        {
                            Posicao origem = item.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }

                        }
                    }
                }
            }
            return true;
        }





        public void colocarNovaPeca(char coluna,int linha, Peca peca)   //Este comando recebe uma coluna, uma linha e uma Peca
                                                                        //ele Colocar a peça atraves do tabuleiro, instancia uma posição de xadrez(coluna,linha) e converte para posicao.
                                                                        //Assim a peca fornecedia como parametro é adicionada no conjunto de pecas;
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);


        }
        private void colocarPecas()                                     //Este metodo auxiliar(privativo) é instanciado no construtor.
                                                                        //o metodo colocarNovaPeca é chamado e seus parametros sao preenchidos conforme a peca e sua posicao no formato de coluna e linha.
        {
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Dama(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(tab, Cor.Branca,this));
            colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('a', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('b', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('f', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('g', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('h', 2, new Peao(tab, Cor.Branca));

            colocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Dama(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Rei(tab, Cor.Preta,this));
            colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('a', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('b', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('c', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('f', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('g', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('h', 7, new Peao(tab, Cor.Preta));

        }


    }
}
