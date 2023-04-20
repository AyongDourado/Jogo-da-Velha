/* Desenvolva um jogo da velha utilizando matrizes em C#. Faça com que cada jogador insira a sua jogada em uma interface amigavel. 
Teste se a posição é válida e caso não seja solicite ao jogador repetir a jogada. Após cada jogada, apresente o tabuleiro com as 
jogadas representadas por "X" e "O" e faça a verficação se algum jogador venceu.
Caso seja empate, apresente o resultado na tela. Possilibilite que o jogo seja reinicializado sem a necessidade de reiniciar o jogo. 

Desafio extra, pode valer por alguma atividade futura: Faça a implementação de um jogo contra o computador. Faça o possível para evitar que o jogador vença do computador. 
Para facilitar, faça com que o computador inicie jogando. */


using System.Xml;

namespace JogoDaVelha
{
    internal class Program
    {
        static bool TemEspaco(char[,] tabuleiro)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i, j] == ' ')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            char[,] tabuleiro = new char[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = ' ';
                }
            }

            int jogador = 2;

            bool invalida = false;
            

            while (true)
            {
                Console.WriteLine("   JOGO DA VELHA");

                Console.WriteLine();
                for (int i = 0; i < 3; i++)
                {
                    if(i == 0)
                    {
                        Console.Write("0 ");
                    }
                    else if (i == 1)
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("2 ");
                    }

                    Console.Write("  ");
                    for (int j = 0; j < 3; j++)
                    {
                        if ((i == 0 && j == 2) || (i == 1 && j == 2) || (i == 2 && j == 2))
                        {
                            Console.Write(tabuleiro[i, j] + "  ");
                        }
                        else
                        {
                            Console.Write(tabuleiro[i, j] + " | ");
                        }

                    }
                    if (i == 0 || i == 1)
                        Console.WriteLine("\n  ----+---+----");
                    else
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("   0    1    2");

                if (!invalida)
                {
                    if (jogador == 1)
                    {
                        jogador++;
                    }
                    else
                    {
                        jogador--;
                    }
                }

                int linha;
                int coluna;
                char jogada;

                if (jogador == 2)
                {
                    Console.WriteLine("Vez do jogador 2 (O)");

                    Console.Write("\nDigite a linha (0 a 2): ");
                    linha = int.Parse(Console.ReadLine());
                    Console.Write("Digite a coluna (0 a 2): ");
                    coluna = int.Parse(Console.ReadLine());

                    if (tabuleiro[linha, coluna] != ' ')
                    {
                        Console.WriteLine("Posição inválida! Tente novamente.");
                        invalida = true;
                        continue;                       
                    }
                    else
                    {
                        tabuleiro[linha, coluna] = 'O';
                        invalida = false;
                    }
                    jogada = 'O';
                }
                else
                {
                    Console.Write("Vez do jogador 1 (X)");

                    Console.Write("\nDigite a linha (0 a 2): ");
                    linha = int.Parse(Console.ReadLine());
                    Console.Write("Digite a coluna (0 a 2): ");
                    coluna = int.Parse(Console.ReadLine());

                    if (tabuleiro[linha, coluna] != ' ')
                    {
                        Console.WriteLine("Posição inválida! Tente novamente.");
                        invalida = true;
                        continue;                       
                    }
                    else
                    {
                        tabuleiro[linha, coluna] = 'X';
                        invalida = false;
                    }
                    jogada = 'X';
                }

                Console.Clear();


                if ((tabuleiro[0, 0] == jogada && tabuleiro[0, 1] == jogada && tabuleiro[0, 2] == jogada) ||     // primeira linha
                   (tabuleiro[1, 0] == jogada && tabuleiro[1, 1] == jogada && tabuleiro[1, 2] == jogada) ||      // segunda linha
                   (tabuleiro[2, 0] == jogada && tabuleiro[2, 1] == jogada && tabuleiro[2, 2] == jogada) ||      // terceira linha
                   (tabuleiro[0, 0] == jogada && tabuleiro[1, 0] == jogada && tabuleiro[2, 0] == jogada) ||      // primeira coluna
                   (tabuleiro[0, 1] == jogada && tabuleiro[1, 1] == jogada && tabuleiro[2, 1] == jogada) ||      // segunda coluna
                   (tabuleiro[0, 2] == jogada && tabuleiro[1, 2] == jogada && tabuleiro[2, 2] == jogada) ||      // terceira coluna
                   (tabuleiro[0, 0] == jogada && tabuleiro[1, 1] == jogada && tabuleiro[2, 2] == jogada) ||      // diagonla principal
                   (tabuleiro[0, 2] == jogada && tabuleiro[1, 1] == jogada && tabuleiro[2, 0] == jogada))        // diagonal secundária
                {

                    Console.WriteLine("\nO jogador " + jogador + " venceu!");

                    Console.WriteLine("Deseja repetir o jogo? Digite 's' para repetir ou qualquer outra tecla para encerrar.");
                    string repetir = Console.ReadLine();
                    if (repetir == "s")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tabuleiro[i, j] = ' ';
                            }
                        }

                        continue;
                    }
                    else
                    {
                        break;
                    }                    
                }
                else if (!TemEspaco(tabuleiro))
                {
                    Console.WriteLine("\nDeu empate!");

                    Console.WriteLine("Deseja repetir o jogo? Digite 's' para repetir ou qualquer outra tecla para encerrar.");
                    string repetir = Console.ReadLine();
                    if (repetir == "s")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tabuleiro[i, j] = ' ';
                            }
                        }
                        continue;
                    }
                    else
                    {
                        break;
                    }                  
                }
                Console.WriteLine();
            }

        }
    }
}
