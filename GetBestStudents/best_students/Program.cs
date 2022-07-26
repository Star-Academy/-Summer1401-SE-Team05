using System;
using System.Text.Json;
using BEST_STUDENTS;
using System.Linq;

namespace BEST_STUDENTS;

class Program
{
    static void Main(string[] args)
    {
        ProgramController programController = new ProgramController();
        programController.run();
        
    }
}