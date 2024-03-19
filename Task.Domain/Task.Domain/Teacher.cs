namespace Task.Domain
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Speciality { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}
