using System;

namespace fourinrow
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            int boardLength = 8;
            int boardWidth = 8;
            int numbersBoard = 8;
            char [,] positions;
            String mudar= "X";
            int jogada;
            int Length = 7;
          


            Console.WriteLine("-------------------");
            Console.WriteLine("     Bem vindo     ");
            Console.WriteLine("-------------------");
            Console.WriteLine("    Four in Row    ");
            Console.WriteLine("-------------------");
            Console.WriteLine("\n");

            Console.WriteLine("Jogador 1, digite o seu nome...\n");
            Players player1 = new Players()
            {
                name = Console.ReadLine(),
                piece = 'X'
            };

            Console.WriteLine("\nJogador 2, digite o seu nome...\n");
            Players player2 = new Players()
            {
                name = Console.ReadLine(),
                piece = 'Y'
            };

            Console.Clear();

            Console.WriteLine($"\n{player1.name} irá jogar com a peça {player1.piece}.\n");
            Console.WriteLine($"\n{player2.name} irá jogar com a peça {player2.piece}.\n");

            //Alimenta o tabuleiro
            positions = new char [boardLength, boardWidth];
            for (int i = 0; i < boardLength; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    positions[i, j] = ' ';
                }
            }

            //desenha as colunas 
            Console.WriteLine();
            for (int i = 0; i <= numbersBoard; i++)
            {
                if (i > 10)
                {
                    Console.Write($" | " + i);
                }
                else if (i == 8)
                {
                    Console.Write($"");
                }
                else if (i <= 9)
                {
                    Console.Write($" | " + i);
                }
            }
            Console.Write(" | ");
            Console.WriteLine();

            // desenha o tabuleiro 
            for (int i = 0; i < positions.GetLength(0); i++)
            {
                Console.WriteLine(" ---------------------------------");
                for (int j = 0; j < positions.GetLength(1); j++)
                {
                    Console.Write(" | " + positions[i, j]);
                }
                Console.Write(" | ");
                Console.WriteLine();
            }
            Console.WriteLine(" ---------------------------------");

            int tentativas = 0;

            //Iniando o jogo
            while (tentativas<16)
            {                
                //Console.WriteLine("-------------------");
                //Console.WriteLine("    Four in Row    ");
                //Console.WriteLine("-------------------");

               for (int k = 7; k < boardLength; k--)
               {
                    for(int l = 7; l < boardWidth; l--)
                    {
                        if (mudar == "X")
                        {
                            Console.WriteLine($"{player1.name} é sua vez de jogar, escolha uma das opçoes disponivel no tabuleiro");
                            jogada = Convert.ToInt32(Console.ReadLine());

                            if (jogada > 7)
                            {
                                Console.WriteLine($"{player1.name} jogada invalida, favor selecionar uma coluna valida");
                                jogada = Convert.ToInt32(Console.ReadLine());
                            }

                            if (positions[Length, jogada] != 'X' && positions[Length, jogada] != 'Y')
                            {
                                positions[Length, jogada] = player1.piece;
                                break;

                            } else
                            {
                                --Length;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{player2.name} é sua vez de jogar, escolha uma das opçoes disponivel no tabuleiro");
                            jogada = Convert.ToInt32(Console.ReadLine());

                            //mudar posicao notabuleiro
                            //

                            if (jogada > 7)
                            {
                                Console.WriteLine($"{player2.name} jogada invalida, favor selecionar uma coluna valida");
                                jogada = Convert.ToInt32(Console.ReadLine());
                            }

                            if (positions[Length, jogada] != 'X' && positions[Length, jogada] != 'Y')
                            {
                                positions[Length, jogada] = player2.piece;
                                break;
                            }
                            else
                            {
                                --Length;                               
                            }

                        }                        
                    }                                    

                    if (mudar == "X")
                    {
                        mudar = "0";
                    }
                    else
                    {
                        mudar = "X";
                    }              

                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine("-------------------");
                    Console.WriteLine("    Four in Row    ");
                    Console.WriteLine("-------------------");
                    Console.WriteLine("\n");
          

                    //desenha as colunas 
                    for (int i = 0; i <= numbersBoard; i++)
                    {
                        if (i > 10)
                        {
                            Console.Write($" | " + i);
                        }
                        else if (i == 8)
                        {
                            Console.Write($"");
                        }
                        else if (i <= 9)
                        {
                            Console.Write($" | " + i);
                        }

                    }
                    Console.Write(" | ");
                    Console.WriteLine();

                    // desenha o tabuleiro 
                    for (int i = 0; i < positions.GetLength(0); i++)
                    {
                        Console.WriteLine(" ---------------------------------");
                        for (int j = 0; j < positions.GetLength(1); j++)
                        {
                            Console.Write(" | " + positions[i, j]);
                        }
                        Console.Write(" | ");
                        Console.WriteLine();
                    }
                    Console.WriteLine("----------------------------------");                
               }
                tentativas++;
            }                        

        }

        public static void CheckWin(string mudar, Char [,] positions)
        {          

            //// Condição de vitória nas Diagonais.
            //if (positions[0, 0] == positions[1, 1] && positions[1, 1] == positions[2, 2] ||
            //        positions[0, 2] == positions[1, 1] && positions[1, 1] == positions[2, 0])
            //{
            
            //    Console.WriteLine("\n--------------");
            //    Console.WriteLine("Fim de Jogo!!!");
            //    Console.WriteLine("--------------");
            //    Console.WriteLine($"\nParabéns!!! O ganhador é [{mudar}].");
            //}

            //// Condição de vitória nas Linhas.
            //if (positions[0, 0] == positions[0, 1] && positions[0, 1] == positions[0, 2] ||
            //    positions[1, 0] == positions[1, 1] && positions[1, 1] == positions[1, 2] ||
            //    positions[2, 0] == positions[2, 1] && positions[2, 1] == positions[2, 2])
            //{

            //    Console.WriteLine("\n--------------");
            //    Console.WriteLine("Fim de Jogo!!!");
            //    Console.WriteLine("--------------");
            //    Console.WriteLine($"\nParabéns!!! O ganhador é [{mudar}].");

            //}

            //// Condição de vitória nas Colunas.
            //if (positions[0, 0] == positions[1, 0] && positions[1, 0] == positions[2, 0] ||
            //    positions[0, 1] == positions[1, 1] && positions[1, 1] == positions[2, 1] ||
            //    positions[0, 2] == positions[1, 2] && positions[1, 2] == positions[2, 2])
            //{
                
            //    Console.WriteLine("\n--------------");
            //    Console.WriteLine("Fim de Jogo!!!");
            //    Console.WriteLine("--------------");
            //    Console.WriteLine($"\nParabéns!!! O ganhador é [{mudar}].");

            //}


            for (int L=0; L<positions.Length; L++)
            {
                for (int C=0; C<positions.Length; C++)
                {
                    if ( positions[L,C] == positions[L, C+1] && positions[L, C+2] == positions[L, C + 3])
                    {
                        Console.WriteLine("\n--------------");
                        Console.WriteLine("Fim de Jogo!!!");
                        Console.WriteLine("--------------");
                        Console.WriteLine($"\nParabéns!!! O ganhador é [{mudar}].");

                    }else if (positions[L, C] == positions[L+1, C] && positions[L+2, C] == positions[L+3, C])
                    {
                        Console.WriteLine("\n--------------");
                        Console.WriteLine("Fim de Jogo!!!");
                        Console.WriteLine("--------------");
                        Console.WriteLine($"\nParabéns!!! O ganhador é [{mudar}].");
                    }
                }
            }


        }

    }
}
