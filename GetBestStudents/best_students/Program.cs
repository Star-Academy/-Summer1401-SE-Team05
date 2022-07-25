using System;
using System.Text.Json;
using BEST_STUDENTS;
using System.Linq;

namespace BEST_STUDENTS;

class Program
{
    static void Main(string[] args)
    {
        string ScoresData;
        using (StreamReader r = new StreamReader("scores.json"))
            {
                ScoresData = r.ReadToEnd();
            }
        using JsonDocument doc1 = JsonDocument.Parse(ScoresData);
        JsonElement root1 = doc1.RootElement;


        var u1 = root1[0];

        //Console.WriteLine(u1.GetProperty("StudentNumber"));

        
        
        string StudentsData;
        using (StreamReader r = new StreamReader("students.json"))
            {
                StudentsData = r.ReadToEnd();
            }
        
        
        using JsonDocument doc2 = JsonDocument.Parse(StudentsData);
        JsonElement root2 = doc2.RootElement;
        int n = root2.GetArrayLength();
        //Console.WriteLine(n);

        var u2 = root2[1];

        //Console.WriteLine(u2.GetProperty("FirstName"));

        List<Student> students = new List<Student>();

        List<JsonElement> scores = new List<JsonElement>();
        for(int i = 0; i < root1.GetArrayLength(); i ++)
        {
            scores.Add(root1[i]);
        }
            
        for(int i = 0; i < n; i++)
        {
            Student student = new Student(root2[i].GetProperty("StudentNumber").GetInt32(), root2[i].GetProperty("FirstName").GetString(), root2[i].GetProperty("LastName").GetString());
            
            List<JsonElement> TempScores = new List<JsonElement>(scores.Where(x => x.GetProperty("StudentNumber").GetInt32() == i + 1));
            
            double sum = 0;
            //Console.WriteLine("    " + TempScores.Count + "   " + i);
            for(int j = 0; j < TempScores.Count; j++)
            {
            //    Console.WriteLine((TempScores[j].GetProperty("Score").GetDouble()) + " " + i + " " + n);
                sum += TempScores[j].GetProperty("Score").GetDouble();
            }

            student.Avg = sum / ((double) TempScores.Count);
            students.Add(student);
        }

        students = students.OrderBy(o=>-o.Avg).ToList();
        for(int i = 0; i < 3; i++) {
            Console.Write(students[i].FirstName + " ");
            Console.WriteLine(students[i].LastName);
            Console.WriteLine(students[i].Avg);
            Console.WriteLine();
        }
    }
}