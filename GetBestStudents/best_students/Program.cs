using System;
using System.Text.Json;
using BEST_STUDENTS;
using System.Linq;

namespace BEST_STUDENTS;

class Program
{
    static void Main(string[] args)
    {
        View view = new View();
        StudentListCreater studentListCreater = new StudentListCreater();
        new ProgramController(view, studentListCreater).Run();
    }
}