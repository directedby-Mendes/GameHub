using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace GameHub.Classes {
    public class GameHubOptions {

        public static void NovoPlayer(List<Jogador> jogadoresAtuais) {

            Console.Write("Digite o nome: ");
            var nome = Console.ReadLine();
            Console.Write("Digite o cpf: ");
            var cpf = Console.ReadLine();
            Console.Write("Digite a senha: ");
            var senha = Console.ReadLine();
            int pontos = 0;

            Jogador jogador = new(nome ?? "", cpf ?? "", senha ?? "", pontos);
            jogadoresAtuais.Add(jogador);
            
            Persistencia persistencia = new Persistencia();
            persistencia.SalvarArquivo(jogadoresAtuais);
            
        }

        public static void Login(List<Jogador> jogador) {

        }

        public static void RankingPlayers(List<string> nome, List<string> cpfs, List<int> pontos) {
            Console.WriteLine("<<<<<Ranking de Players>>>>>\n");

            for (int i = 0; i < pontos.Count; i++) {
                // Console.WriteLine($"Posição {i + 1} → Nome: {nome[i]} CPF: {cpfs[i]} com Pontuação:{pontos[i]:F2}");
                Console.WriteLine($"Posição {i + 1} → Nome: {nome[i]} com Pontuação:{pontos[i]:F2}");
            }
            
            Console.ReadKey();
            Console.Clear(); 
            
        }
    }
}