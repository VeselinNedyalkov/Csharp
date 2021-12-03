using System;
using System.Linq;
using System.Collections.Generic;

namespace Objects_and_Classes___More_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Employee>> employee = new Dictionary<string, List<Employee>>();

            int numberEmploye = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberEmploye; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                double salary = double.Parse(input[1]);
                string department = input[2];
                
                if(!employee.ContainsKey(department))
                    employee.Add(department, new List<Employee>());
                if (employee.ContainsKey(department))
                    employee[department].Add(new Employee(name, salary, department));
            }
            string highestSalaryDep = "";
            double highestSalary = 0;

            foreach (var deparment in employee)
            {
                double sum = 0;
                foreach (var salary in deparment.Value)
                {
                    sum += salary.Salary;
                    if (sum > highestSalary)
                    {
                        highestSalary = sum;
                        highestSalaryDep = deparment.Key;
                    }
                }
            }

            Console.WriteLine($"Highest Average Salary: {highestSalaryDep}");
            foreach (var item in employee)
            {
                if (item.Key == highestSalaryDep)
                {
                    foreach (var name in item.Value.OrderByDescending(x => x.Salary))
                    {
                        Console.WriteLine($"{name.Name} {name.Salary:f2}");
                    }
                }
            }
        }

        
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name , double salary,string department)
        {
            Name = name;    
            Salary = salary;
            Department = department;
        }
    }
}
