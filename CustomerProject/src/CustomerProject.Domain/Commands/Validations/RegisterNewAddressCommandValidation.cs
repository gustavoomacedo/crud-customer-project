using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Commands.Validations
{
    public class RegisterNewAddressCommandValidation : AddressValidation<RegisterNewAddressCommand>
    {
        public RegisterNewAddressCommandValidation()
        {
            ValidatePostalCode();
            ValidateStreet();
            ValidateStreetNumber();
            ValidateCity();
            ValidateState();
            ValidateId();
        }
    }
}
