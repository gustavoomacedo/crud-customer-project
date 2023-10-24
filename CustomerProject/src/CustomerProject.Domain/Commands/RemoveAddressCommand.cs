using CustomerProject.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Commands
{
    public class RemoveAddressCommand : AddressCommand
    {
        public RemoveAddressCommand(Guid id)
        {
            CustomerId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveAddressCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
