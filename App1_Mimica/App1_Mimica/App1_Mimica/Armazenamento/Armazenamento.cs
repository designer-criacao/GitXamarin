using System;
using System.Collections.Generic;
using System.Text;
using App1_Mimica.Model;

namespace App1_Mimica.Armazenamento
{
    public class Armazenamento
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }

        public static string[][] Palavras =
        {
            //Fácil Pontuação 1
            new string[] {"Bocejo", "Interruptor", "Planta", "Milho", "Penalti", "Bola", "Ping-Pong"},
            
            //Médio Pontuação 3
            new string[] {"Carpinteiro", "Imã", "Limão", "Abelha", "Magro", "Sacrifício", "Profundidade"},

            //Dificil Pontuação 5
            new string[] {"Cineasta", "Lanterna", "Batman vs Superman", "Notebook", "Espinhos", "Capacete", "Parede"},
        };
    }
}
