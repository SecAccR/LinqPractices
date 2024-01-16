using System;
using System.Collections.Generic;
using LinqPractices.DBOperations;
using LinqPractices.Entities;

namespace LinqPractices;

class Program
{
    static void Run(string[] args)
    {
        DataSeeder.Seed();
        LinqDbContext _context = new LinqDbContext();

        while (true)
        {
            if (!int.TryParse(GetInputFromUser("Please enter"), out int input))
            {
                Console.WriteLine("Value is not numeric!");
            }
            else if (input < 1)
            {
                Console.WriteLine($"Error: value must be greater than zero! input: {input}");
                break;
            }
            else
            {
                foreach (Student student in _context.Students)
                {
                    Console.WriteLine($"Id: {student.Id} Name: {student.Name} Surname: {student.Surname} ClassId: {student.ClassId}");
                }
            }
        }
    }

    static string GetInputFromUser(string message, int limit = 3)
    {
        if (limit == 0)
        {
            throw new Exception("Input is invalid, maximum retry number exceeded!");
        }

        Console.Write($"{message}: ");

        string? input = Console.ReadLine();

        if (input is null) input = GetInputFromUser(message, limit - 1);

        return input;
    }

    static void Main(string[] args)
    {
        try
        {
            Run(args);
            if (Console.ReadLine() == "clear") Console.Clear();
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp);
        }
    }
}