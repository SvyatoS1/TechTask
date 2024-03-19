using FluentValidation;
using Task.DAL.Repositories.Interfaces;
using Task.Domain;
using Task.BLL.Resourses;

namespace Task.BLL.Validation
{
    public class TeacherValidator : AbstractValidator<Teacher>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public TeacherValidator(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;

            RuleFor(t => t.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(Errors.IdIsNull)
                .GreaterThan(0)
                .WithMessage(Errors.IdLessThan);

            RuleFor(t => t.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(Errors.NameIsEmpty)
                .MinimumLength(Constants.NameMinLenght)
                .WithMessage(Errors.NameIsLessThan)
                .MaximumLength(Constants.NameMaxLenght)
                .WithMessage(Errors.NameIsGreaterThan);

            RuleFor(t => t.Surname)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(Errors.SurnameIsEmpty)
                .MinimumLength(Constants.SurnameMinLenght)
                .WithMessage(Errors.SurnameIsLessThan)
                .MaximumLength(Constants.SurnameMaxLenght)
                .WithMessage(Errors.SurnameIsGreaterThan);

            RuleFor(t => t.Speciality)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(Errors.SpecialityIsEmpty)
                .MinimumLength(Constants.SpecialityMinLenght)
                .WithMessage(Errors.SpecialityIsLessThan)
                .MaximumLength(Constants.SpecialityMaxLenght)
                .WithMessage(Errors.SpecialityIsGreaterThan);

        }
    }
}
