using CustomerProject.Domain.Commands.Validations;
using CustomerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Commands
{
    public class RegisterNewAddressCommand : AddressCommand
    {
        public RegisterNewAddressCommand(string postalCode, string street, string streetNumber, 
                                        string complementaryAddress, string city, string state, Guid customerID)
        {
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
            ValidationResult = new RegisterNewAddressCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
