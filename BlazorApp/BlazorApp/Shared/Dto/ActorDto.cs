using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Dto
{
   public  class ActorDto
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        public int YearsActive { get; set; }
        public string? Photo { get; set; }
        public string? Biography { get; set; }
    }

    public class ActorDtoValidator : AbstractValidator<ActorDto>
    {
        public ActorDtoValidator()
        {
            RuleFor(f => f.FirstName)
                .NotEmpty()
                .MaximumLength(30)
                .WithName("First Name");

            RuleFor(f => f.LastName)
                .NotEmpty()
                .MaximumLength(35)
                .WithName("Last Name");

            RuleFor(f => f.DateOfBirth)
                .NotEmpty()
                .WithMessage("Birthday");

            RuleFor(f => f.YearsActive)
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Years");

            RuleFor(f => f.Photo)
               .NotEmpty()
               .WithMessage("Photo");

            RuleFor(f => f.Biography)
                .NotEmpty()
                .MaximumLength(100)
                .WithName("Biography");
        }
    }
}
