using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GameHub.Classes {
    public class Persistencia {
        //LER ARQUIVO
        public List<Jogador> LerArquivo(string caminho) {

            //Console.WriteLine(caminho);
            if (File.Exists(caminho)) {
                //Lê o arquivo em uma string
                string text = File.ReadAllText(caminho);
                //Tras para obj
                var jogadores = JsonSerializer.Deserialize<List<Jogador>>(text);

                if (jogadores != null) {
                    //OBJ EM JSON
                    //Console.WriteLine(JsonSerializer.Serialize(jogadores));
                    return jogadores.ToList();

                    // Console.WriteLine(jogadores.ToString);
                }
            }
            return new List<Jogador>();
        }

        public async void SalvarArquivo(List<Jogador> jogadorSalvar) {
        //TRANSFORMANDO EM STRING 
            var salvarArquivo = JsonSerializer.Serialize(jogadorSalvar);
           // Console.WriteLine(salvarArquivo);
            //Salvando no JSON
            await File.WriteAllTextAsync(@"C:\Users\Diego\Desktop\Ima\GameHub\GameHub\GameHub\Classes\Dados.json", salvarArquivo);
            Console.Clear();
            Program.GameHubMenu();
        }
    }
}
