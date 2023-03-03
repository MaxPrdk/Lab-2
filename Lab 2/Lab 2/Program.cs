using System;
using System.IO;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public double GPA { get; set; }
}

class Program
{
    static void Main()
    {
       
        var students = File.ReadAllLines("students.csv")
            .Skip(1) // Skip the header row
            .Select(line => {
                var parts = line.Split(',');
                return new Student
                {
                    Name = parts[0],
                    Grade = int.Parse(parts[1]),
                    GPA = double.Parse(parts[2])
                };
            })
            .ToList();

      
        var highGpaStudents = students
            .Where(s => s.GPA >= 3.5)
            .ToList();

        
        Console.WriteLine("Students with a GPA of 3.5 or higher:");
        foreach (var student in highGpaStudents)
        {
            Console.WriteLine(student.Name);
        }
    }
}