using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.Validation;
using Task.DAL.Repositories.Interfaces;
using Task.WebApi.Conrollers;

namespace Task.Test
{
    public class StudentsEndpointTest
    {
        private readonly Mock<IStudentRepository> _mockStudentRepository;
        private readonly Mock<StudentValidator> _mockStudentValidator;

        public StudentsEndpointTest(Mock<IStudentRepository> mockStudentRepository, Mock<StudentValidator> mockStudentValidator)
        {
            _mockStudentRepository = mockStudentRepository;
            _mockStudentValidator = mockStudentValidator;
        }

        [Fact]
        public async Task GetAllStudents_Sucessfully()
        {

        }
    }
}
