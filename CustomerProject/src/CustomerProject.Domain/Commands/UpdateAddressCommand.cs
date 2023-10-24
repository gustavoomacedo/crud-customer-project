using CustomerProject.Domain.Commands.Validations;
using CustomerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Commands
{
    public class UpdateAddressCommand : AddressCommand
    {
        public UpdateAddressCommand(Guid id, string postalCode, string street, string streetNumber,
                                        string complementaryAddress, string city, string state, Guid customerID)
        {
            Id = id;
            PostalCode = postalCode;
            Street = street;
            StreetNumber = streetNumber;
            ComplementaryAddress = complementaryAddress;
            City = city;
            State = state;
            CustomerId = customerID;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateAddressCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
