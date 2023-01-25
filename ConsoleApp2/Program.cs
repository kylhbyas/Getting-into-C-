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
        /*
         * Declared as abstract so it can be overridden
         * 
         * Since private fields cannot be accessed by derived 
         *  classes the public helper fuctions were neccessary.
         *  
         */
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

        /*
         * Cat inherits from Animal and overrides its abstract methods.
         * 
         */
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

        /*
         * Inherits from Animal and overrides its abstract methods.
         * 
         */
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

        /*
         * Inherits from animal and overrides its abstract methods.
         * 
         */
        class Fox : Animal
        {
            public Fox (string petName, int petAge, string petNoise, int petWeight)
            {
                whatName = petName;
                whatAge = petAge;
                whatNoise = petNoise;
                whatWeight = petWeight;
            }
            public override void PrintInfo()
            {
                Console.WriteLine("Name: " + whatName);
                Console.WriteLine("Species: Fox");
                Console.WriteLine("Age: " + whatAge);
                Console.WriteLine("Noise: " + whatNoise);
                Console.WriteLine("Weight: " + whatWeight);
            }
            public override void MakeNoise()
            {
                Console.WriteLine("Usually " + whatNoise + " but sometimes... Ring-ding-ding-ding-dingeringeding!");
            }
            public override void AgeUp()
            {
                whatAge++;
            }
        }

        /*
         * Main is in here and everthing else as well
         * 
         */
        class World
        {
            /*
             * Menu defined here for readability
             * 
             */
            public static void Menu()
            {
                Console.WriteLine(" 1 - Add animal");
                Console.WriteLine(" 2 - Print an animal's info");
                Console.WriteLine(" 3 - Hear an animal's noise");
                Console.WriteLine(" 4 - Increase an animal's age by one year");
                Console.WriteLine(" 9 - Exit");
            }

            /*
             * Records an animal's stats and adds that animal to the list
             * 
             */
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

                if (species == "fox")
                {
                    Fox fox = new Fox(petName, petAge, petNoise, petWeight);
                    Zoo.Add(fox);
                }
            }
            /*
             * Iterates through the list and returns the selected index
             *  , defined here for readability
             * 
             */
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
                    if (choice == 1)
                    {
                        Builder(Zoo);
                        Console.WriteLine("Done!");
                    }
                    if (choice == 2)
                    {
                        int index2 = Which(Zoo);

                        Zoo[index2].PrintInfo();
                    }
                    if (choice == 3)
                    {
                        int index3 = Which(Zoo);

                        Console.WriteLine("\"" + Zoo[index3].whatNoise + "\"");
                    }
                    if (choice == 4)
                    {
                        int index4 = Which(Zoo);
                        Zoo[index4].AgeUp();

                        Console.WriteLine("One year has passed...");
                        Console.WriteLine(Zoo[index4].whatName + " is now " + Zoo[index4].whatAge + " years old");
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
