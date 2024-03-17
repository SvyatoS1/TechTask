using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Persistence;
using Task.DAL.Repositories.Interfaces;

namespace Task.DAL.Repositories.Realization
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly TaskDbContext _taskDbContext;

        private ICourseRepository _courseRepository;
        private ITeacherRepository _teacherRepository;
        private IStudentRepository _studentRepository;
        public ICourseRepository CourseRepository 
        {
            get
            {
                _courseRepository ??= new CourseRepository(_taskDbContext);

                return _courseRepository;
            }
        }
        public ITeacherRepository TeacherRepository 
        {
            get
            {
                _teacherRepository ??= new TeacherRepository(_taskDbContext);

                return _teacherRepository;
            }
        }
        public IStudentRepository StudentRepository 
        {
            get
            {
                _studentRepository ??= new StudentRepository(_taskDbContext);

                return _studentRepository;
            }
        }

        public int SaveChanges()
        {
            return _taskDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _taskDbContext.SaveChangesAsync();
        }
    }
}
