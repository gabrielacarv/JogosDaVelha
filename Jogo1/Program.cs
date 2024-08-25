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
                            EscolherJogada(program.tabuleiro, 'O');
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

        public static int CalcularPeso(char[,] tabuleiro, int linha, int coluna, char jogador)
        {
            Program program = new Program();
            char[,] tabuleiroCopia = (char[,])tabuleiro.Clone();
            int peso = 0;


            if (linha == 1 && coluna == 1)
                peso += 2;

            if ((linha == 0 || linha == 2) && (coluna == 0 || coluna == 2))
                peso += 1;

            char oponente = 'X';
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiroCopia[linha, i] == oponente || tabuleiroCopia[i, coluna] == oponente)
                {
                    peso -= 2;
                    break;
                }
            }
            if ((linha == coluna || linha + coluna == 2) && (tabuleiroCopia[0, 0] == oponente || tabuleiroCopia[0, 2] == oponente || tabuleiroCopia[2, 0] == oponente || tabuleiroCopia[2, 2] == oponente))
                peso -= 2;

            tabuleiroCopia[linha, coluna] = 'X';
            if (program.VerificarVitoria(tabuleiroCopia, 'X'))
                peso += 4;
            tabuleiroCopia[linha, coluna] = ' ';

            tabuleiroCopia[linha, coluna] = 'O';
            if (program.VerificarVitoria(tabuleiroCopia, 'O'))
                peso += 4;

            return peso;
        }

        public static void EscolherJogada(char[,] tabuleiro, char jogador)
        {
            Program program = new Program();
            char[,] tabuleiroCopia = (char[,])tabuleiro.Clone();
            int[,] peso = new int[3, 3];
            int maiorPeso = int.MinValue;
            int k = 0;
            int l = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiroCopia[i, j] == ' ')
                    {
                        peso[i, j] = CalcularPeso(tabuleiroCopia, i, j, jogador);
                        if (peso[i, j] > maiorPeso)
                        {
                            maiorPeso = peso[i, j];
                            k = i;
                            l = j;
                        }
                    }
                }
            }

            tabuleiro[k, l] = jogador;

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
