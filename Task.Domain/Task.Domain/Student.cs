using Task.Domain;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public IEnumerable<StudentCourse> Courses { get; set; }
}
