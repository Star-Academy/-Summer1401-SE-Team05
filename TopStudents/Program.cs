using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TopStudents;

class Program
{
    public static void Main(string[] args)
    {
        using (var context = new PeopleContext())
        {
            foreach (var student in context.Students.OrderByDescending(x => x.Avg).Take(3).ToList())
            {
                Console.WriteLine(student);
            }
        }
    }

}