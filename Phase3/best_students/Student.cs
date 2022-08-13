using System.Text.Json;
using DefaultNamespace;

namespace BEST_STUDENTS;

public class Student
{
    public int StudentNumber{get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public double Avg {get; set;}

    public Student(int studentNumber, string firstName, string lastName) 
    {
        StudentNumber = studentNumber;
        FirstName = firstName;
        LastName = lastName;
    }

    public bool ScoreIsForStudent(Grade grade)
    {
        return grade.StudentNumber == StudentNumber;
    }
    
    public override string ToString()
    {
        return $"{FirstName} {LastName}: \n {Avg}";
    }
}
