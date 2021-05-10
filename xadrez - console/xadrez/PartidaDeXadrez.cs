using System;
using tabuleiro;
namespace xadrez
{
    class PartidaDeXadrez
    {
        //PartidaDeXadrez relacionada a mecanica do jogo de xadrez
        //A classe faz ligação com o tabuleiro e possui um turno e uma Cor relacionada ao jogador atual
        //A classe começa instanciando o tamanho do tabuleiro, com o turno = 1 e o jogador atual recebe a cor Branca, pois o turno começa com as brancas
        //O construtor recebe um metodo suporte que é o colocarPecas(), onde ele poem a Peca(o tabuleiro, e sua cor), e Insancia a classe PosicaoXadrez(informando um char(coluna) e um int(linha),
        //e utiliza o metodo toPosicao() para converter para numeros relacionados a matriz(converter para o formato da classe Posicao)

        public Tabuleiro tab { get; private set; }

        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }


        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimenots();
            Peca pecaCaputarada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);



        }
        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c',1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());


            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());



        }


    }
}
