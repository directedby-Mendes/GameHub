using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace GameHub.Classes {
    public class Jogador {
        
        public string Name {get; set;}
        public string Cpf {get; set;}
        public string Senha {get; set;}
        public int Pontos {get; set;}

        public Jogador(string name, string cpf, string senha, int pontos) {
            Name = name;
            Cpf = cpf;
            Senha = senha;
            Pontos = pontos;
        }             
    }
}

