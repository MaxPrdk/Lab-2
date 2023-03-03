using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    delegate int StringLengthDelegate(string s);

    static void Main()
    {
       
        var strings = new List<string> { "apple", "banana", "cherry" };

        
        StringLengthDelegate lengthDelegate = s => s.Length;


        var lengths = strings
            .Select(lengthDelegate)
            .ToList();

        Console.WriteLine("String lengths:");
        foreach (var length in lengths)
        {
            Console.WriteLine(length);
        }
    }
}
