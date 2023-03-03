using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Employee
{
    public string Name { get; set; }
    public int YearsOfExperience { get; set; }
    public decimal Salary { get; set; }
}

class Program
{
    static void Main()
    {
        
        var employees = File.ReadAllLines("employees.csv")
            .Skip(1) 
            .Select(line => {
                var parts = line.Split(',');
                return new Employee
                {
                    Name = parts[0],
                    YearsOfExperience = int.Parse(parts[1]),
                    Salary = decimal.Parse(parts[2])
                };
            })
            .ToList();
        
        var sortedEmployees = employees
            .OrderByDescending(e => e.Salary)
            .ToList();

        Console.WriteLine("Employees sorted by salary:");
        foreach (var employee in sortedEmployees)
        {
            Console.WriteLine($"{employee.Name} - {employee.Salary:C}");
        }
    }
}
