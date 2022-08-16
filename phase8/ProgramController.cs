namespace TopStudents;

public class ProgramController
{
    public void Run()
    {
        initDataBase();
        
        using (var context = new PeopleContext())
        {
            foreach (var student in context.Students.OrderByDescending(x => x.Avg).Take(3).ToList())
            {
                Console.WriteLine(student);
            }
        }
    }

    public void initDataBase()
    {
        try
        {
            new DatabaseInitializer().Run();
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
        {
            Console.WriteLine("database was already initialized");
        }

    }
}