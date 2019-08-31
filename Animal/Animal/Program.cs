using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
   public class Animals: IEnumerable
    {
        private List<Animal> animals = new List<Animal>();

        public void AddPrimate(string name, bool hasTail)
        {
            animals.Add(new Animal {Name = name, Type = Animal.Category.Primate});
        }
        public void AddReptile(string name, bool hasTail)
        {
            animals.Add(new Animal { Name = name, Type = Animal.Category.Reptile});
        }
        public void AddMammal(string name, bool hasTail)
        {
            animals.Add(new Animal { Name = name, Type = Animal.Category.Mammal});
        }
        public IEnumerator GetEnumerator()
        {
            foreach (Animal theAnimal in animals)
            {
                yield return theAnimal.Name;
            }
        }
        public IEnumerable Primate
        {
            get
            {
                return Categorise(Animal.Category.Primate);
            }
        }
        public IEnumerable Reptile
        {
            get
            {
                return Categorise(Animal.Category.Reptile);
            }
        }
        public IEnumerable Mammal
        {
            get
            {
                return Categorise(Animal.Category.Mammal);
            }
        }
        private IEnumerable Categorise(Animal.Category type)
        {
            foreach (Animal theAnimal in animals)
            {
                if (theAnimal.Type == type)
                {
                    yield return theAnimal.Name;
                }
            }
        }

        private class Animal
        {
            public string Name { get; set; }

            public enum Category
            {
                Primate,
                Reptile,
                Mammal
            }

            public Category Type { get; set; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Animals animal = new Animals(); 

            animal.AddMammal("Hippopotamus", true);
            animal.AddMammal("Lion", true);
            animal.AddMammal("Zebra", true);
            animal.AddMammal("Cheetah", true);
            animal.AddMammal("Giraffe", true);
            animal.AddPrimate("Baboon", true);
            animal.AddPrimate("Chimpanzee", true);
            animal.AddPrimate("Gorilla", false);
            animal.AddReptile("Crocodile", true);
            animal.AddReptile("Snakes", false);
            animal.AddReptile("Lizard", true);

            foreach (string name in animal.Mammal)
            {
                Console.WriteLine(name + " ");
            }

            Console.WriteLine();

            foreach (string name in animal.Primate)
            {
                Console.WriteLine(name + " ");
            }

            Console.WriteLine();

            foreach (string name in animal.Reptile)
            {
                Console.WriteLine(name + " ");
            }

            Console.WriteLine();

            Console.ReadKey();

        }
    }
}
