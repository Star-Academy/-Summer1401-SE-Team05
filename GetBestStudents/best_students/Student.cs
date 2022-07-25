namespace BEST_STUDENTS;

public class Student
{
    public int StudentNumber{get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public double Avg {get; set;}

    public Student(int StudentNumber, string FirstName, string LastName) 
    {
        this.StudentNumber = StudentNumber;
        this.FirstName = FirstName;
        this.LastName = LastName;
    }

}
