using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Commands.Validations
{
    public abstract class AddressValidation<T> : AbstractValidator<T> where T : AddressCommand
    {
        protected void ValidatePostalCode()
        {
            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage("Please ensure you have entered the PostalCode")
                .Length(2, 10).WithMessage("The PostalCode must have between 2 and 10 characters");
        }

        protected void ValidateStreet()
        {
            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("Please ensure you have entered the Street")
                .Length(2, 500).WithMessage("The Street must have between 2 and 500 characters");
        }

        protected void ValidateStreetNumber()
        {
            RuleFor(c => c.StreetNumber)
                .NotEmpty().WithMessage("Please ensure you have entered the StreetNumber")
                .Length(2, 500).WithMessage("The StreetNumber must have between 2 and 500 characters");
        }

        protected void ValidateCity()
        {
            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Please ensure you have entered the City")
                .Length(2, 500).WithMessage("The City must have between 2 and 500 characters");
        }

        protected void ValidateState()
        {
            RuleFor(c => c.State)
                .NotEmpty().WithMessage("Please ensure you have entered the State")
                .Length(2, 500).WithMessage("The State must have between 2 and 500 characters");
        }
        protected void ValidateId()
        {
            RuleFor(c => c.CustomerId)
                .NotEqual(Guid.Empty);
        }
    }
}
