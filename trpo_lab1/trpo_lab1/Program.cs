using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trpo_lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WolfCollection wolfCollection = new WolfCollection();
            Wolf wolf1 = new Wolf("Auf", 4, "Gray");
            Wolf wolf2 = new Wolf("Auf2", 4, "Black");
            Wolf wolf3 = new Wolf("Auf3", 4, "Bro");
            Wolf wolf4 = new Wolf("Auf4", 4, "Gray");

            wolfCollection.Add(wolf1);
            wolfCollection.Add(wolf2);
            wolfCollection.Add(wolf3);
            wolfCollection.Add(wolf4);

            Console.WriteLine(wolfCollection.GetList().Contains(wolf4));
            Console.WriteLine(wolfCollection.GetArrayList().Contains(wolf4));

            Wolf[] wolves = new Wolf[4];
            wolfCollection.CopyTo(wolves, 0);
            Console.WriteLine("\nWolves copied to array:");
            foreach (Wolf wolf in wolves)
            {
                Console.WriteLine(wolf.ToString());
            }
          
            Console.WriteLine("\nArrayList");
            foreach (var wolf in wolfCollection.GetArrayList())
            {
                Console.WriteLine(wolf.ToString());
            }

            Console.WriteLine("\nList");
            foreach (var wolf in wolfCollection.GetList())
            {
                Console.WriteLine(wolf.ToString());
            }
        }
    }
}
