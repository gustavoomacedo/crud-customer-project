using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Commands.Validations
{
    public class UpdateAddressCommandValidation : AddressValidation<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidation()
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
