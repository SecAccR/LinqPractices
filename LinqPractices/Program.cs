using System;
using System.Collections.Generic;
using System.Linq;
using LinqPractices.DBOperations;
using LinqPractices.Entities;

namespace LinqPractices;

class Program
{
    static void Run(string[] args)
    {
        DataSeeder.Seed();
        LinqDbContext _context = new LinqDbContext();

        foreach (Student student in _context.Students)
        {
            Console.WriteLine(StudentText(student));
        }
        Console.WriteLine();

        Console.WriteLine("Find: {0}", StudentText(_context.Students.Find(2)));
        Console.WriteLine("FirstOrDefault: {0}", StudentText(_context.Students.FirstOrDefault(x => x.Surname.Equals("Arda"))));
        Console.WriteLine("SingleOrDefault: {0}", StudentText(_context.Students.SingleOrDefault(x => x.Surname.Equals("Tembel"))));
        Console.WriteLine("OrderBy:");
        foreach (Student student in _context.Students.OrderBy(x => x.Name).ToList())
        {
            Console.WriteLine(StudentText(student));
        }
        Console.WriteLine("Anonymous Object Result:");
        var anonymousObject = _context.Students.Where(x => x.ClassId == 2).Select(x => new { Id = x.Id, FullName = x.Name + " " + x.Surname });

        foreach (var anObj in anonymousObject)
        {
            Console.WriteLine($"Id: {anObj.Id} FullName: {anObj.FullName}");
        }
    }

    static string StudentText(Student student)
    {
        return $"Id: {student.Id} Name: {student.Name} Surname: {student.Surname} ClassId: {student.ClassId}";
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