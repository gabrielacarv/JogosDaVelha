using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercício_5
{
    internal class Program
    {
        public char[,] tabuleiro = new char[3, 3];
        string[,] posicoes = new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        int jogadasMax = 0;

        static void Main(string[] args)
        {
            Program program = new Program();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                program.ZeraTabuleiro();
                int opcao = program.Menu();

                switch (opcao)
                {
                    case 1:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            program.ImprimirTabuleiro();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("JOGADOR 1 - (X)");
                            Console.ResetColor();
                            program.MarcarPosicao('X');
                            program.jogadasMax++;
                            if (program.VerificarVitoria(program.tabuleiro, 'X'))
                            {
                                Console.Clear();
                                program.ImprimirTabuleiro();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Jogador 1  VENCEU!");
                                Console.ResetColor();
                                break;
                            }

                            Console.Clear();
                            Console.WriteLine();
                            program.ImprimirTabuleiro();
                            Console.WriteLine();
                            Console.WriteLine();
                            if (program.VerificaEmpate())
                            {
                                Thread.Sleep(3000);
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("JOGADOR 2 - (O)");
                            Console.ResetColor();
                            program.MarcarPosicao('O');
                            program.jogadasMax++;
                            if (program.VerificarVitoria(program.tabuleiro, 'O'))
                            {
                                Console.Clear();
                                program.ImprimirTabuleiro();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Jogador 2  VENCEU!");
                                Console.ResetColor();
                                break;
                            }


                        }
                        break;

                    case 2:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            program.ImprimirTabuleiro();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("JOGADOR 1 - (X)");
                            Console.ResetColor();
                            program.MarcarPosicao('X');
                            program.jogadasMax++;
                            if (program.VerificarVitoria(program.tabuleiro, 'X'))
                            {
                                Console.Clear();
                                program.ImprimirTabuleiro();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Jogador 1  VENCEU!");
                                Console.ResetColor();
                                Thread.Sleep(3000);
                                break;
                            }


                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine();
                            program.ImprimirTabuleiro();
                            Console.WriteLine();
                            Console.WriteLine();
                            if (program.VerificaEmpate())
                            {
                                Thread.Sleep(3000);
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("JOGADOR 2 - (O)");
                            Console.ResetColor();
                            EscolherJogadaMinimax(program.tabuleiro);
                            program.jogadasMax++;
                            Console.Clear();
                            program.ImprimirTabuleiro();
                            if (program.VerificarVitoria(program.tabuleiro, 'O'))
                            {
                                Console.Clear();
                                program.ImprimirTabuleiro();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Máquina VENCEU!");
                                Console.ResetColor();
                                break;
                            }
                        }
                        break;

                    case 3:
                        return;


                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida, tente novamente!");
                        break;
                }
            }
        }

        public int Menu()
        {
            Console.WriteLine("----------------- MENU -----------------");
            Console.WriteLine(" 1 - Iniciar novo jogo Humano vs Humano");
            Console.WriteLine(" 2 - Iniciar novo jogo Humano vs Máquina");
            Console.WriteLine(" 3 - Sair");
            Console.WriteLine("----------------------------------------");
            Console.Write("Digite o número correspondente a opção que deseja:");
            int opcao = int.Parse(Console.ReadLine());

            return opcao;
        }

        public void ZeraTabuleiro()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = ' ';
                }
            }
            jogadasMax = 0;
        }

        public void ImprimirTabuleiro()
        {
            Console.WriteLine("### JOGO DA VELHA ###");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"      {tabuleiro[0, 0]} | {tabuleiro[0, 1]} | {tabuleiro[0, 2]}");
            Console.WriteLine($"     -----------");
            Console.WriteLine($"      {tabuleiro[1, 0]} | {tabuleiro[1, 1]} | {tabuleiro[1, 2]}");
            Console.WriteLine($"     -----------");
            Console.WriteLine($"      {tabuleiro[2, 0]} | {tabuleiro[2, 1]} | {tabuleiro[2, 2]}");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Gabarito das posições");
            Console.WriteLine($"      {posicoes[0, 0]} | {posicoes[0, 1]} | {posicoes[0, 2]}");
            Console.WriteLine($"     -----------");
            Console.WriteLine($"      {posicoes[1, 0]} | {posicoes[1, 1]} | {posicoes[1, 2]}");
            Console.WriteLine($"     -----------");
            Console.WriteLine($"      {posicoes[2, 0]} | {posicoes[2, 1]} | {posicoes[2, 2]}");
        }

        public void MarcarPosicao(char jogador)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Digite a posição que deseja marcar o '{jogador}': ");
                string entrada = Console.ReadLine();

                #region verificação
                if (entrada.Length != 1 || (int.Parse(entrada) < 1 && int.Parse(entrada) > 9))
                {
                    Console.WriteLine("Valor inválido!");
                    continue;
                }

                if (int.Parse(entrada) == 1)
                {
                    if (tabuleiro[0, 0] != ' ')
                    {
                        Console.WriteLine("Posição já ocupada, tente novamente!");
                        continue;
                    }
                }
                else if (int.Parse(entrada) == 2)
                {
                    if (tabuleiro[0, 1] != ' ')
                    {
                        Console.WriteLine("Posição já ocupada, tente novamente!");
                        continue;
                    }
                }
                else if (int.Parse(entrada) == 3)
                {
                    if (tabuleiro[0, 2] != ' ')
                    {
                        Console.WriteLine("Posição já ocupada, tente novamente!");
                        continue;
                    }
                }
                else if (int.Parse(entrada) == 4)
                {
                    if (tabuleiro[1, 0] != ' ')
                    {
                        Console.WriteLine("Posição já ocupada, tente novamente!");
                        continue;
                    }
                }
                else if (int.Parse(entrada) == 5)
                {
                    if (tabuleiro[1, 1] != ' ')
                    {
                        Console.WriteLine("Posição já ocupada, tente novamente!");
                        continue;
                    }
                }
                else if (int.Parse(entrada) == 6)
                {
                    if (tabuleiro[1, 2] != ' ')
                    {
                        Console.WriteLine("Posição já ocupada, tente novamente!");
                        continue;
                    }
                }
                else if (int.Parse(entrada) == 7)
                {
                    if (tabuleiro[2, 0] != ' ')
                    {
                        Console.WriteLine("Posição já ocupada, tente novamente!");
                        continue;
                    }
                }
                else if (int.Parse(entrada) == 8)
                {
                    if (tabuleiro[2, 1] != ' ')
                    {
                        Console.WriteLine("Posição já ocupada, tente novamente!");
                        continue;
                    }
                }
                else if (int.Parse(entrada) == 9)
                {
                    if (tabuleiro[2, 2] != ' ')
                    {
                        Console.WriteLine("Posição já ocupada, tente novamente!");
                        continue;
                    }
                }
                #endregion verificação

                #region inserindo no tabuleiro
                if (int.Parse(entrada) == 1)
                {
                    tabuleiro[0, 0] = jogador;
                }
                else if (int.Parse(entrada) == 2)
                {
                    tabuleiro[0, 1] = jogador;
                }
                else if (int.Parse(entrada) == 3)
                {
                    tabuleiro[0, 2] = jogador;
                }
                else if (int.Parse(entrada) == 4)
                {
                    tabuleiro[1, 0] = jogador;
                }
                else if (int.Parse(entrada) == 5)
                {
                    tabuleiro[1, 1] = jogador;
                }
                else if (int.Parse(entrada) == 6)
                {
                    tabuleiro[1, 2] = jogador;
                }
                else if (int.Parse(entrada) == 7)
                {
                    tabuleiro[2, 0] = jogador;
                }
                else if (int.Parse(entrada) == 8)
                {
                    tabuleiro[2, 1] = jogador;
                }
                else if (int.Parse(entrada) == 9)
                {
                    tabuleiro[2, 2] = jogador;
                }
                #endregion inserindo no tabuleiro

                break;
            }
        }

        public bool VerificarVitoria(char[,] tabuleiro, char jogador)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[i, 0] == jogador && tabuleiro[i, 1] == jogador && tabuleiro[i, 2] == jogador)
                {
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[0, i] == jogador && tabuleiro[1, i] == jogador && tabuleiro[2, i] == jogador)
                {
                    return true;
                }
            }

            if (tabuleiro[0, 0] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 2] == jogador)
            {
                return true;
            }

            if (tabuleiro[0, 2] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 0] == jogador)
            {
                return true;
            }

            return false;
        }

        public static int Minimax(char[,] tabuleiro, int profundidade, bool isMaximizing)
        {
            Program program = new Program();

            if (program.VerificarVitoria(tabuleiro, 'O')) return 10 - profundidade;
            if (program.VerificarVitoria(tabuleiro, 'X')) return profundidade - 10;
            if (program.VerificaEmpate()) return 0;

            if (isMaximizing)
            {
                int melhorPontuacao = int.MinValue;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (tabuleiro[i, j] == ' ')
                        {
                            tabuleiro[i, j] = 'O';
                            int pontuacao = Minimax(tabuleiro, profundidade + 1, false);
                            tabuleiro[i, j] = ' ';
                            melhorPontuacao = Math.Max(pontuacao, melhorPontuacao);
                        }
                    }
                }
                return melhorPontuacao;
            }
            else
            {
                int melhorPontuacao = int.MaxValue;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (tabuleiro[i, j] == ' ')
                        {
                            tabuleiro[i, j] = 'X';
                            int pontuacao = Minimax(tabuleiro, profundidade + 1, true);
                            tabuleiro[i, j] = ' ';
                            melhorPontuacao = Math.Min(pontuacao, melhorPontuacao);
                        }
                    }
                }
                return melhorPontuacao;
            }
        }

        public static void EscolherJogadaMinimax(char[,] tabuleiro)
        {
            Program program = new Program();
            int melhorPontuacao = int.MinValue;
            int melhorLinha = -1;
            int melhorColuna = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i, j] == ' ')
                    {
                        tabuleiro[i, j] = 'O';
                        int pontuacao = Minimax(tabuleiro, 0, false);
                        tabuleiro[i, j] = ' ';

                        if (pontuacao > melhorPontuacao)
                        {
                            melhorPontuacao = pontuacao;
                            melhorLinha = i;
                            melhorColuna = j;
                        }
                    }
                }
            }

            tabuleiro[melhorLinha, melhorColuna] = 'O';
        }

        public bool VerificaEmpate()
        {
            if (jogadasMax == 9)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Empate!");
                Console.ResetColor();
                return true;
            }
            return false;
        }

    }
}
