using LamarCodeGeneration.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameHub.Classes {
    public class JogoDaVelha {

        public void InicializarTabuleiro() {

            int player = 1;
            string simbolo = "X";
            int posição = 1;
            int tentativas = 1;
            List<string> numeros = new List<string>();
            string[,] matriz = new string[3, 3];


            //PREENCHENDO A MATRIZ.
            for (int i = 0; i < matriz.GetLength(0); i++) {
                for (int j = 0; j < matriz.GetLength(1); j++) {
                    matriz[i, j] = posição.ToString();
                    numeros.Add(posição.ToString());
                    posição++;
                }

            }
            //IMPRIMINDO A MATRIZ.
            Console.Clear();
            Console.WriteLine("<<<JOGO DA VELHA>>>\n");
            for (int i = 0; i < matriz.GetLength(0); i++) {
                for (int j = 0; j < matriz.GetLength(1); j++) {
                    Console.Write($"  [{matriz[i, j]}]");

                }
                Console.Write("\n");
            }
            string jogada = null;
            Console.Clear();

            //VALIDANDO SIMBOLOS NO CAMPO CERTO

            while (tentativas <= 9) {
                Console.WriteLine("***********************");
                Console.WriteLine(" Jogando Jogo da Velha");
                Console.WriteLine("***********************");

                for (int i = 0; i < matriz.GetLength(0); i++) {
                    for (int j = 0; j < matriz.GetLength(1); j++) {
                        if (matriz[i, j] == jogada && numeros.Contains(jogada)) {
                            matriz[i, j] = simbolo;
                            numeros.Remove(jogada);
                        }
                    }
                }

                //IMPRESSÃO DO TABULEIRO COM OS SIMBOLOS            
                for (int i = 0; i < matriz.GetLength(0); i++) {
                    for (int j = 0; j < matriz.GetLength(1); j++) {
                        Console.Write($"  [{matriz[i, j]}]");

                    }
                    Console.Write("\n");
                }
                
                Vitoria(matriz,player,simbolo);

                //ALTERAR SIMBOLOS OS JOGADORES
                if (simbolo == "X") {
                    simbolo = "O";
                    player = 1;
                }
                else {
                    simbolo = "X";
                    player = 2;
                }

                Console.WriteLine($"\n\n");
                Console.WriteLine($"É a vez o Jogador {player}");
                Console.Write($"Digite o numero do Campo que Deseja inserir o {simbolo}: ");
                jogada = Console.ReadLine();
                tentativas++;

                while (!numeros.Contains(jogada)) {
                    Console.WriteLine("\n");
                    Console.WriteLine("Digito invalido, Por favor inserir nova posição");
                    jogada = Console.ReadLine();
                }
                Console.Clear();

            }
        }

        public static void Vitoria(string[,] matriz, int player , string simbolo) {
            //VALIDAÇÃO DIAGONAIS
            
            if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2] ||
                matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0]) {
                Console.WriteLine("\n");
                Console.WriteLine("Jogo Finalizado");
                Console.WriteLine($"\nParabéns!!! O Ganhador é o Player[{player}] com Simbolo {simbolo}");
                Console.ReadKey();
                Program.GameHubMenu();
            }

            //VALIDAÇÃO NAS 3 LINHAS
            if (matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2] ||
                matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2] ||
                matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2]) {
                Console.WriteLine("\n");
                Console.WriteLine("Jogo Finalizado");
                Console.WriteLine($"\nParabéns!!! O Ganhador é o Player[{player}] com Simbolo {simbolo}");
                Console.ReadKey();
                Program.GameHubMenu();
            }
            //VALIDAÇÃO NAS 3 COLUNAS
            if (matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0] ||
               matriz[0, 1] == matriz[1, 1] && matriz[1, 1] == matriz[2, 1] ||
               matriz[0, 2] == matriz[1, 2] && matriz[2, 1] == matriz[2, 2]) {
                
                Console.WriteLine("Jogo Finalizado");
                Console.WriteLine($"\nParabéns!!! O Ganhador é o Player[{player}] com Simbolo {simbolo}");
                Console.ReadKey();
                Program.GameHubMenu();
            }
        }
    }
}



