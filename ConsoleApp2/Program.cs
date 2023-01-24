/*
 * Kyle Byassee
 * 2023-01-24
 * This program lets you interact with animals
 * 
 * This program is lit.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        abstract class Animal
        {
            private string Name;
            private int Age;
            private string Noise;
            private int Weight;

            public string whatName
            {
                get
                {
                    return Name;
                }
                set
                {
                    Name = value;
                }
            }
            public int whatAge
            {
                get
                {
                    return Age;
                }
                set
                {
                    Age = value;
                }
            }
            public string whatNoise
            {
                get
                {
                    return Noise;
                }
                set
                {
                    Noise = value;
                }
            }
            public int whatWeight
            {
                get
                {
                    return Weight;
                }
                set
                {
                    Weight = value;
                }
            }

            public abstract void PrintInfo();
            public abstract void MakeNoise();
            public abstract void AgeUp();
        }

        class Cat : Animal
        {
            public Cat (string petName, int petAge, string petNoise, int petWeight)
            {
                whatName = petName;
                whatAge = petAge;
                whatNoise = petNoise;
                whatWeight = petWeight;
            }
            public override void PrintInfo()
            {
                Console.WriteLine("Name: " + whatName);
                Console.WriteLine("Species: Cat");
                Console.WriteLine("Age: " + whatAge);
                Console.WriteLine("Noise: " + whatNoise);
                Console.WriteLine("Weight: " + whatWeight);
            }
            public override void MakeNoise()
            {
                Console.WriteLine("Usually " + whatNoise + " but sometimes... meow");
            }
            public override void AgeUp()
            {
                whatAge++;
            }
        }

        class Cassowary : Animal
        {
            public Cassowary (string petName, int petAge, string petNoise, int petWeight)
            {
                whatName = petName;
                whatAge = petAge;
                whatNoise = petNoise;
                whatWeight = petWeight;
            }
            public override void PrintInfo()
            {
                Console.WriteLine("Name: " + whatName);
                Console.WriteLine("Species: Cassowary");
                Console.WriteLine("Age: " + whatAge);
                Console.WriteLine("Noise: " + whatNoise);
                Console.WriteLine("Weight: " + whatWeight);
            }
            public override void MakeNoise()
            {
                Console.WriteLine("Usually " + whatNoise + " but sometimes... Caw!");
            }
            public override void AgeUp()
            {
                whatAge++;
            }
        }

        class World
        {
            
            public static void Menu()
            {
                Console.WriteLine(" 1 - Add animal");
                Console.WriteLine(" 2 - Print an animal's info");
                Console.WriteLine(" 3 - Hear an animal's noise");
                Console.WriteLine(" 4 - Increase an animal's age by one year");
                Console.WriteLine(" 9 - Exit");
            }

            public static void Builder(List<Animal> Zoo)
            {
                Console.WriteLine("What species?");
                string species = Console.ReadLine();
                species = species.ToLower();

                Console.WriteLine("Name?");
                string petName = Console.ReadLine();
                petName = petName[0].ToString().ToUpper() + petName.Substring(1);

                Console.WriteLine("Age?");
                string tempAge = Console.ReadLine();
                int petAge = Int32.Parse(tempAge);

                Console.WriteLine("Noise?");
                string petNoise = Console.ReadLine();

                Console.WriteLine("Weight?");
                string tempWeight = Console.ReadLine();
                int petWeight = Int32.Parse(tempWeight);

                if (species == "cat")
                {
                    Cat cat = new Cat(petName, petAge, petNoise, petWeight);
                    Zoo.Add(cat);
                }

                if (species == "cassowary")
                {
                    Cassowary cassowary = new Cassowary(petName, petAge, petNoise, petWeight);
                    Zoo.Add(cassowary);
                }
            }

            public static int Which(List<Animal> Zoo)
            {
                Console.WriteLine("Which animal?");

                for (int i = 0; i < Zoo.Count; i++)
                {
                    int j = i + 1;
                    Console.WriteLine(" " + j + " - " + Zoo[i].whatName);
                }
                int index = Convert.ToInt32(Console.ReadLine()) - 1;

                return index;
            }
            
            static void Main(string[] args)
            {
                List<Animal> Zoo = new List<Animal>();

                Console.WriteLine("Hello, welcome to the World");
                Console.WriteLine("Please Select from one of the following options:");
                Menu();
                int choice = Convert.ToInt32(Console.ReadLine());

                while (choice != 9)
                {
                    if(choice == 1)
                    {
                        Builder(Zoo);
                        Console.WriteLine("Done!");
                    }
                    if (choice == 2)
                    {
                        int temp2 = Which(Zoo);

                        Zoo[temp2].PrintInfo();
                    }
                    if (choice == 3)
                    {
                        int temp3 = Which(Zoo);

                        Console.WriteLine("\"" + Zoo[temp3].whatNoise + "\"");
                    }
                    if (choice == 4)
                    {
                        int temp4 = Which(Zoo);
                        Zoo[temp4].AgeUp();

                        Console.WriteLine("One year has passed...");
                        Console.WriteLine(Zoo[temp4].whatName + " is now " + Zoo[temp4].whatAge + " years old");
                    }

                    Console.WriteLine("");
                    Menu();
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                //Console.ReadKey();
            }
        }
    }
}
