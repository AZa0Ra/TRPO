using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trpo_lab1;

namespace trpo_lab1G
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplexCollection<ComplexNum> complexCollection = new ComplexCollection<ComplexNum>();
            ComplexNum complexNum1 = new ComplexNum(11, 21);
            ComplexNum complexNum2 = new ComplexNum(22, 32);
            ComplexNum complexNum3 = new ComplexNum(33, 43);
            ComplexNum complexNum4 = new ComplexNum(44, 54);
            ComplexNum complexNum5 = new ComplexNum(55, 65);
            
            complexCollection.Add(complexNum1);
            complexCollection.Add(complexNum2);
            complexCollection.Add(complexNum3);
            complexCollection.Add(complexNum4);
            complexCollection.Add(complexNum5);

            Console.WriteLine($"Element numbers: {complexCollection.Count}\n");

            foreach (ComplexNum complexNum in complexCollection.GetStack())
            {
                Console.WriteLine(complexNum.ToString());
            }

            foreach (ComplexNum complexNum in complexCollection.GetArrayStack())
            {
                Console.WriteLine(complexNum.ToString());
            }

        }
    }
}
