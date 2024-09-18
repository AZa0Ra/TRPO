using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trpo_lab1
{
    internal class Wolf
    {
        public Wolf(string name, int age, string breed)
        {
            Name = name;
            Age = age;
            Breed = breed;
        }

        public string Name { get; set; }
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value > 0)
                    _age = value;
            }
        }
        public string Breed { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Breed: {Breed}";
        }
    }
}
