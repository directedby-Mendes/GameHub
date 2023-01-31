using System;
using System.Collections.Generic;
using System.Web;
using DryIoc;
using GameHub.Classes;
using System.Xml;
using System.Collections.Generic;
using System.Reflection;
using LamarCodeGeneration.Frames;
using System.Runtime.Intrinsics.X86;
using System.Linq;
namespace GameHub {
    public class Program {

        public static void GameHubMenu() {
            Console.WriteLine("*******************************");
            Console.WriteLine("*  Bem-Vindo ao Hub de Jogos  *");
            Console.WriteLine("*******************************");

            Console.WriteLine("1 - Cadastrar Players");
            Console.WriteLine("2 - Jogo da Velha");
            Console.WriteLine("3 - Batalha Naval");
            Console.WriteLine("4 - Ranking de Players");
            Console.WriteLine("0 - Parar Programa");
            Console.WriteLine("\n\n");
            Console.Write("Escolha uma opção para começar: ");
        }
        public static void Main(string[] args) {
            Persistencia persistencia = new();
            var jogadores = persistencia.LerArquivo(@"C:\Users\Diego\Desktop\Ima\GameHub\GameHub\GameHub\Classes\Dados.json");

            JogoDaVelha velha = new JogoDaVelha();
            // BatalhaNaval btnaval = new BatalhaNaval();
            //List<string> jogador = new List<Jogador>();

            var jogadoresOrdenados = jogadores.OrderByDescending(jogadores => jogadores.Pontos);
            List<string> nome = jogadoresOrdenados.Select(x => x.Name).ToList();
            List<string> cpfs = jogadoresOrdenados.Select(x => x.Cpf).ToList();
            List<string> senhas = new List<string>();
            List<int> pontos = (from jogador in jogadoresOrdenados select jogador.Pontos).ToList(); 


            int option;
            do {
                GameHubMenu();
                option = int.Parse(Console.ReadLine());
                switch (option) {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Operação Finalizada");
                        break;
                    case 1:
                        Console.Clear();
                        GameHubOptions.NovoPlayer(jogadores);
                        break;
                    case 2:
                        Console.Clear();
                        //INICIANDO A MATRIZ.                      
                        velha.InicializarTabuleiro();
                        break;
                    case 3:
                        Console.Clear();
                        //BatalhaNaval.btnaval(nome, cpfs, pontos);
                        break;
                    case 4:
                        Console.Clear();
                        GameHubOptions.RankingPlayers(nome, cpfs, pontos);
                        break;
                }
            } while (option > 4);


        }
    }
}