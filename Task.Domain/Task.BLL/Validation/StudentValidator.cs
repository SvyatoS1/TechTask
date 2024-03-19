using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.Resourses;
using Task.DAL.Repositories.Interfaces;
using Task.Domain;

namespace Task.BLL.Validation
{
    public class StudentValidator : AbstractValidator<Student>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public StudentValidator(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;

            RuleFor(s => s.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(Errors.IdIsNull)
                .GreaterThan(0)
                .WithMessage(Errors.IdLessThan);

            RuleFor(s => s.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(Errors.NameIsEmpty)
                .MinimumLength(Constants.NameMinLenght)
                .WithMessage(Errors.NameIsLessThan)
                .MaximumLength(Constants.NameMaxLenght)
                .WithMessage(Errors.NameIsGreaterThan);

            RuleFor(s => s.Surname)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(Errors.SurnameIsEmpty)
                .MinimumLength(Constants.SurnameMinLenght)
                .WithMessage(Errors.SurnameIsLessThan)
                .MaximumLength(Constants.SurnameMaxLenght)
                .WithMessage(Errors.SurnameIsGreaterThan);
        }
    }
}
