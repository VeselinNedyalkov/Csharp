using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
           

            //•	Birds - "{Type} {Name} {Weight} {WingSize}"
            
            string[] inputAnimals = Console.ReadLine().Split();
            while (inputAnimals[0] != "End")
            {
                string[] foodInput = Console.ReadLine().Split();
                string foodName = foodInput[0];
                int foodEaten = int.Parse(foodInput[1]);

                string typeAnimal = inputAnimals[0];

                try
                {
                    switch (typeAnimal)
                    {
                        case "Hen":
                            string name = inputAnimals[1];
                            double weight = double.Parse(inputAnimals[2]);
                            double wingSize = double.Parse(inputAnimals[3]);
                            IAnimal hen = new Hen(name, weight, wingSize);
                            animals.Add(hen);
                            hen.TryToEat(foodName, foodEaten);
                            break;

                        case "Owl":
                            name = inputAnimals[1];
                            weight = double.Parse(inputAnimals[2]);
                            wingSize = double.Parse(inputAnimals[3]);
                            IAnimal owl = new Owl(name, weight, wingSize);
                            animals.Add(owl);
                            owl.TryToEat(foodName, foodEaten);
                            break;

                        case "Mouse":
                            name = inputAnimals[1];
                            weight = double.Parse(inputAnimals[2]);
                            string livingReagin = inputAnimals[3];
                            IAnimal mouse = new Mouse(name, weight, livingReagin);
                            animals.Add(mouse);
                            mouse.TryToEat(foodName, foodEaten);
                            break;

                        case "Cat":
                            name = inputAnimals[1];
                            weight = double.Parse(inputAnimals[2]);
                            livingReagin = inputAnimals[3];
                            string breed = inputAnimals[4];
                            IAnimal cat = new Cat(name, weight, livingReagin, breed);
                            animals.Add(cat);
                            cat.TryToEat(foodName, foodEaten);
                            break;

                        case "Dog":
                            name = inputAnimals[1];
                            weight = double.Parse(inputAnimals[2]);
                            livingReagin = inputAnimals[3];
                            IAnimal dog = new Dog(name, weight, livingReagin);
                            animals.Add(dog);
                            dog.TryToEat(foodName, foodEaten);
                            break;

                        case "Tiger":
                            name = inputAnimals[1];
                            weight = double.Parse(inputAnimals[2]);
                            livingReagin = inputAnimals[3];
                            breed = inputAnimals[4];
                            IAnimal tiger = new Tiger(name, weight, livingReagin, breed);
                            animals.Add(tiger);
                            tiger.TryToEat(foodName, foodEaten);
                            break;

                        default:
                            break;
                    }                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                inputAnimals = Console.ReadLine().Split();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
