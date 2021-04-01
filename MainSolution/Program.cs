using MainSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainSolution
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("The main project it's running");
        }

        public static int solution(int[] A, int[] B)
        {
            var fishes = parseFishes(A, B);
            var downstreamFishes = new List<Fish>(); // para considerar todos los peces que estan bajando

            foreach (var fish in fishes)
            {
                if (fish.direction == FishDirection.Upstream) // aqui el pez esta subiendo
                {
                    if (downstreamFishes.Count(f => f.isAlive) == 0) // Un pez que sube, si no encuentra ningun pez que baja vivira para siempre.
                        continue;

                    for (int i = downstreamFishes.Count - 1; i >= 0; i--) // Combatimos a nuestro pez subiente contra todos los bajantes.
                    {
                        var contenderFish = downstreamFishes[i];
                        if (!contenderFish.isAlive) //Si el pez bajante 
                            continue;

                        if (contenderFish.size > fish.size)
                        {
                            fish.isAlive = false;
                            break;
                        }

                        if (contenderFish.size < fish.size)
                            fishes.Find(f => f.id == contenderFish.id).isAlive = false;
                    }
                }
                else
                { // aqui el pez esta bajando
                    downstreamFishes.Add(fish);
                }
            }
            return fishes.Count(f => f.isAlive);
        }

        public static List<Fish> parseFishes(int[] A, int[] B)
        {
            List<Fish> response = new List<Fish>();
            for (int i = 0; i < A.Length; i++)
            {
                var size = A[i];
                FishDirection direction;
                switch (B[i])
                {
                    case 0:
                        direction = FishDirection.Upstream;
                        break;
                    default:
                        direction = FishDirection.Downstream;
                        break;
                }
                var aFish = new Fish(size, direction);
                response.Add(aFish);
            }
            return response;
        }
    }
}
