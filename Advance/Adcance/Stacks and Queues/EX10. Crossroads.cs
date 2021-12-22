using System;
using System.Collections.Generic;

namespace Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int secGreenLight = int.Parse(Console.ReadLine());
            int additionalSec = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int carPass = 0;
            string car;


            while ((car = Console.ReadLine()) != "END")
            {
                if (car == "green")
                {
                    int timeLeft = secGreenLight;
                    while (cars.Count > 0 && timeLeft > 0) //till we have cars in the queue
                    {
                        string carInTraffic = cars.Dequeue();
                        int carLength = carInTraffic.Length;

                        //reduce the timeleft
                        timeLeft -= carLength;

                        //if timeleft is negative number the car is int he traffic
                        if (timeLeft < 0)
                        {
                            timeLeft += additionalSec;

                            //if timeleft is negative the car crash
                            if (timeLeft < 0)
                            {
                                //calculate the index of hit
                                int inexOfHit = carLength + timeLeft;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carInTraffic} was hit at {carInTraffic[inexOfHit]}.");
                                return;
                            }
                            else
                            {
                                //if car can pass in the additional time add to the count
                                carPass++;
                                break;
                            }
                        }
                        else
                        {
                            //add 1 to the count                         
                            carPass++;
                        }
                    }
                }
                else
                    cars.Enqueue(car);
                                                               
            }


            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carPass} total cars passed the crossroads.");

        }
    }
}

//The road Sam is on has a single lane where cars queue up until the light goes green.
// When it does, they start passing one by one during the green light and the free window before the intersecting road’s light goes green. 
//During one second only one part of a car (a single character) passes the crossroads. If a car is still in the crossroads when the free window ends,
//it will get hit at the first character that is still in the crossroads.
//Input
//•	On the first line, you will receive the duration of the green light in seconds – an integer in the range [1-100]
//•	On the second line, you will receive the duration of the free window in seconds – an integer in the range [0-100]
//•	On the following lines, until you receive the "END" command, you will receive one of two things:
//	A car – a string containing any ASCII character, or
//	The command "green" which indicates the start of a green light cycle
//A green light cycle goes as follows:
//•	During the green light cars will enter and exit the crossroads one by one
//•	During the free window cars will only exit the crossroads

