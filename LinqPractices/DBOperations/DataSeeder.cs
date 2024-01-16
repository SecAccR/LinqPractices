using System.Collections.Generic;
using System.Linq;
using LinqPractices.Entities;

namespace LinqPractices.DBOperations;

public class DataSeeder
{
    public static void Seed()
    {
        using (LinqDbContext context = new LinqDbContext())
        {
            if (context.Students.Any()) return;

            context.Students.AddRange([
                new Student(1, "Ayşe", "Yılmaz", 1),
                new Student(2, "Deniz", "Arda", 1),
                new Student(3, "Umut", "Arda", 2),
                new Student(4, "Merve", "Tembel", 2)
            ]);

            context.SaveChanges();
        }
    }
}