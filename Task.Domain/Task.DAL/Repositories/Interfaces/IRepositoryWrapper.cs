using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        public ICourseRepository CourseRepository {get;}
        public ITeacherRepository TeacherRepository {get;}
        public IStudentRepository StudentRepository {get;}

        public int SaveChanges();

        public Task<int> SaveChangesAsync();
    }
}
