using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main()
    {
        
        var products = File.ReadAllLines("products.csv")
            .Skip(1) // Skip the header row
            .Select(line => {
                var parts = line.Split(',');
                return new Product
                {
                    Name = parts[0],
                    Category = parts[1],
                    Price = decimal.Parse(parts[2])
                };
            })
            .ToList();
       
        var groupedProducts = products
            .GroupBy(p => p.Category)
            .ToList();

        Console.WriteLine("Products grouped by category:");
        foreach (var group in groupedProducts)
        {
            Console.WriteLine($"{group.Key}:");
            foreach (var product in group)
            {
                Console.WriteLine($" - {product.Name} ({product.Price:C})");
            }
        }
    }
}
