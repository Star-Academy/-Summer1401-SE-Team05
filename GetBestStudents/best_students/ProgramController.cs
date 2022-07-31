using System.Text.Json;
using DefaultNamespace;

namespace BEST_STUDENTS;

class ProgramController
{
    private View _view;
    private StudentListCreater _studentListCreater;

    public ProgramController(View view, StudentListCreater studentListCreater)
    {
        _view = view;
        _studentListCreater = studentListCreater;
    }
    public void Run()
    {
        string scoresData = getDataAtPath("scores.json");
        string studentsData = getDataAtPath("students.json");
        
        List<Grade> grades = CreateScoresList(scoresData);
        List<Student> students = _studentListCreater.CreateStudentsList(studentsData);
        students = _studentListCreater.AddStudentAverages(students, grades);
        _view.PrintList(students.OrderByDescending(o=>o.Avg).ToList().Take(3));
    }

    private List<Grade> CreateScoresList(string scoreData)
    {
        return JsonSerializer.Deserialize<List<Grade>>(scoreData);
    }

    private string getDataAtPath(string path)
    {
        string data;
        StreamReader r = new StreamReader(path);
        return r.ReadToEnd();
    }
    
}