using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using MvcApplication3.Models;

namespace MvcApplication3.Validators
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentViewModel>
    {
        public UpdateStudentValidator()
        {
            RuleFor(x => x.StudentId).NotNull().WithMessage("Student Id must not be empty");
            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Student Name must not be empty");
        }
    }
}