using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TopStudents;

class Program
{
    public static void Main(string[] args)
    {
       new ProgramController().Run();
    }

}