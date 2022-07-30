using System.Text.Json;

namespace BEST_STUDENTS;

public class Student
{
    public int StudentNumber{get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public double Avg {get; set;}

    public Student(int studentNumber, string firstName, string lastName) 
    {
        this.StudentNumber = studentNumber;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public Student(JsonElement studentElement)
    {
        StudentNumber = studentElement.GetProperty("StudentNumber").GetInt32();
        FirstName = studentElement.GetProperty("FirstName").GetString();
        LastName = studentElement.GetProperty("LastName").GetString();
    }

    public bool ScoreIsForStudent(JsonElement score)
    {
        return score.GetProperty("StudentNumber").GetInt32() == StudentNumber;
    }
    
    public override string ToString()
    {
        return $"{FirstName} {LastName} {StudentNumber}: \n {Avg}";
    }
}
