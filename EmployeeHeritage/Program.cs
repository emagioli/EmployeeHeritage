using System;
using System.Collections.Generic;
using System.Globalization;
using EmployeeHeritage.Entities;

namespace EmployeeHeritage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of employees: ");
            int employeesNumber = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 1; i <= employeesNumber; i++)
            {
                Console.WriteLine($"Employee #{i} data:");
                Console.Write($"Outsorced (y/n)? ");
                char outsource = char.Parse(Console.ReadLine());
                Employee employee;

                for (char c = outsource; c != 'y' && c != 'Y' && c != 'n' && c != 'N';)
                {
                    Console.Write("Invalid option, please try again.");
                    Console.Write($"Outsorced (y/n)? ");
                    outsource = char.Parse(Console.ReadLine());
                }
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (outsource == 'y' || outsource == 'Y')
                {
                    Console.Write("Additional charge: ");
                    double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    employees.Add(new OutsourceEmployee(name, hours, valuePerHour, additionalCharge));
                }
                else
                {
                    employees.Add(new Employee(name, hours, valuePerHour));
                }
            }
            Console.WriteLine();
            Console.WriteLine("PAYMENTS:");
            foreach (Employee e in employees)
            {
                Console.WriteLine($"{e.Name} - $ {e.Payment().ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
    }
}
