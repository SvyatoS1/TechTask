using FluentValidation;
using Task.BLL.Resourses;
using Task.DAL.Repositories.Interfaces;
using Task.Domain;

namespace Task.BLL.Validation
{
    public class CourseValidator : AbstractValidator<Course>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public CourseValidator (IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(Errors.IdIsNull)
                .GreaterThan(0)
                .WithMessage(Errors.IdLessThan);

            RuleFor(c => c.Title)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(Errors.TitleIsEmpty)
                .MinimumLength(Constants.TitleMinLenght)
                .WithMessage(Errors.TitleIsLessThan)
                .MaximumLength(Constants.TitleMaxLenght)
                .WithMessage(Errors.TitleIsGreaterThan);

            RuleFor(c => c.Description)
                .Cascade (CascadeMode.Stop)
                .MaximumLength(Constants.DescriptionMaxLenght)
                .WithMessage(Errors.DescriptionIsGreaterThan);

            RuleFor(c=>c.TeacherId) 
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(Errors.TeacherIdIsNull)
                .GreaterThan(0)
                .WithMessage(Errors.TeacherIdLessThan);

        }
    }
}
