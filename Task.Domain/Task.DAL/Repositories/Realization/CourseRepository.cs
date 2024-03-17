using Task.DAL.Persistence;
using Task.DAL.Repositories.Interfaces;
using Task.Domain;

namespace Task.DAL.Repositories.Realization
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(TaskDbContext dbContext) : base(dbContext) { }
    }
}
