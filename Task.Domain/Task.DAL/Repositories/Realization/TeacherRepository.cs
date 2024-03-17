using Task.DAL.Persistence;
using Task.DAL.Repositories.Interfaces;
using Task.Domain;

namespace Task.DAL.Repositories.Realization
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(TaskDbContext dbContext) : base(dbContext) { }
    }
}
