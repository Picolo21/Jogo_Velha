internal class Program
{
    private static void Main(string[] args)
    {
        char[,] mat = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        int[] vetPos = new int[3] { 1, 2, 3 };
        char vezDeJogar = 'X';
        int jogadas = 0;
        int posicaoX;
        int posicaoY;
        char[] posicao = new char[2];

        TelaInicial();
        Console.WriteLine();
        Console.WriteLine("Aperte ENTER para iniciar uma partida!");
        Console.ReadKey();

        do
        {
            Console.Clear();
            ImprimirJogo();
            Console.WriteLine();
            Console.WriteLine("Jogada " + (jogadas + 1) + ": Jogador " + vezDeJogar);
            Console.Write("\nDigite a linha que deseja jogar: ");
            posicaoX = int.Parse(Console.ReadLine());
            Console.Write("Digite a coluna que deseja jogar: ");
            posicaoY = int.Parse(Console.ReadLine());
            posicao[0] = (char)(posicaoX - 1);
            posicao[1] = (char)(posicaoY - 1);
            Console.WriteLine();
            if (JogadaInvalida())
            {
                do
                {
                    Console.WriteLine("Jogada inválida. Por favor, insira uma posição válida.");
                    Console.Write("\nDigite a linha que deseja jogar: ");
                    posicaoX = int.Parse(Console.ReadLine());
                    Console.Write("Digite a coluna que deseja jogar: ");
                    posicaoY = int.Parse(Console.ReadLine());
                    posicao[0] = (char)(posicaoX - 1);
                    posicao[1] = (char)(posicaoY - 1);
                    Console.WriteLine();
                } while (JogadaInvalida());
            }
            VerificarJogada();
            RealizarJogada(posicao[0], posicao[1]);
            Console.Clear();
            ImprimirJogo();
            Console.WriteLine();
            Console.WriteLine("Jogada " + (jogadas + 1) + ": Jogador " + vezDeJogar);
            Console.Write("\nEscolha uma posição para jogar: " + posicao);
            if ((CondicaoParada() == true) && (jogadas >= 4))
            {
                Console.WriteLine();
                Console.WriteLine($"Jogador {vezDeJogar} venceu a partida!!!");
                break;
            }
            else if ((CondicaoParada() == false) && (jogadas == 8))
            {
                Console.WriteLine("\n");
                Console.WriteLine("Velha!");
            }
            vezDeJogar = TrocarJogador();
            jogadas++;
        } while (jogadas < 9);

        void TelaInicial()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("   JOGO DA VELHA   ");
            Console.WriteLine("-------------------");

            Console.Write("\n");
            Console.Write($"   {vetPos[0]}   {vetPos[1]}   {vetPos[2]} ");
            Console.WriteLine();

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                Console.Write($"{vetPos[i]} ");
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (j != 2)
                    {
                        Console.Write(" " + mat[i, j] + " ");
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" " + mat[i, j] + " ");
                    }
                }

                if (i != 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("  ---+---+---");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        void ImprimirJogo()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("   JOGO DA VELHA   ");
            Console.WriteLine("-------------------");

            Console.Write("\n");
            Console.Write($"   {vetPos[0]}   {vetPos[1]}   {vetPos[2]} ");
            Console.WriteLine();

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                Console.Write($"{vetPos[i]} ");
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (j != 2)
                    {
                        Console.Write(" " + mat[i, j] + " ");
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" " + mat[i, j] + " ");
                    }
                }

                if (i != 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("  ---+---+---");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        bool JogadaInvalida()
        {
            if ((posicaoX != 1) && (posicaoX != 2) && (posicaoX != 3) ||
                (posicaoY != 1) && (posicaoY != 2) && (posicaoY != 3))
            {
                return true;
            }
            return false;
        }

        void RealizarJogada(char posicao1, char posicao2)
        {
            if (mat[(posicao1), (posicao2)] == ' ')
            {
                mat[(posicao1), (posicao2)] = vezDeJogar;
            }

        }

        void VerificarJogada()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if ((posicao.Equals('X')) || (posicao.Equals('O')))
                    {
                        Console.WriteLine("Posição já está preenchida. Por favor, escolha outra posição");
                        Console.Write("\nDigite a linha que deseja jogar: ");
                        posicaoX = int.Parse(Console.ReadLine());
                        Console.Write("Digite a coluna que deseja jogar: ");
                        posicaoY = int.Parse(Console.ReadLine());
                        posicao[0] = (char)(posicaoX - 1);
                        posicao[1] = (char)(posicaoY - 1);
                    }
                }
            }
        }

        char TrocarJogador()
        {
            if (vezDeJogar == 'X')
            {
                return 'O';
            }
            return 'X';
        }

        bool CondicaoParada()
        {
            if (((mat[0, 0] == 'X') && (mat[0, 1] == 'X') && (mat[0, 2] == 'X')) ||
                ((mat[1, 0] == 'X') && (mat[1, 1] == 'X') && (mat[1, 2] == 'X')) ||
                ((mat[2, 0] == 'X') && (mat[2, 1] == 'X') && (mat[2, 2] == 'X')) ||
                ((mat[0, 0] == 'X') && (mat[1, 0] == 'X') && (mat[2, 0] == 'X')) ||
                ((mat[0, 1] == 'X') && (mat[1, 1] == 'X') && (mat[2, 1] == 'X')) ||
                ((mat[0, 2] == 'X') && (mat[1, 2] == 'X') && (mat[2, 2] == 'X')) ||
                ((mat[0, 0] == 'X') && (mat[1, 1] == 'X') && (mat[2, 2] == 'X')) ||
                ((mat[0, 2] == 'X') && (mat[1, 1] == 'X') && (mat[2, 0] == 'X')))
            {
                return true;
            }
            if (((mat[0, 0] == 'O') && (mat[0, 1] == 'O') && (mat[0, 2] == 'O')) ||
                ((mat[1, 0] == 'O') && (mat[1, 1] == 'O') && (mat[1, 2] == 'O')) ||
                ((mat[2, 0] == 'O') && (mat[2, 1] == 'O') && (mat[2, 2] == 'O')) ||
                ((mat[0, 0] == 'O') && (mat[1, 0] == 'O') && (mat[2, 0] == 'O')) ||
                ((mat[0, 1] == 'O') && (mat[1, 1] == 'O') && (mat[2, 1] == 'O')) ||
                ((mat[0, 2] == 'O') && (mat[1, 2] == 'O') && (mat[2, 2] == 'O')) ||
                ((mat[0, 0] == 'O') && (mat[1, 1] == 'O') && (mat[2, 2] == 'O')) ||
                ((mat[0, 2] == 'O') && (mat[1, 1] == 'O') && (mat[2, 0] == 'O')))
            {
                return true;
            }
            return false;
        }
    }
}