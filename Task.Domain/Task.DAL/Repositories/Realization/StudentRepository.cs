using Task.DAL.Persistence;
using Task.DAL.Repositories.Interfaces;

namespace Task.DAL.Repositories.Realization
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(TaskDbContext dbContext) : base(dbContext) { }
    }
}
