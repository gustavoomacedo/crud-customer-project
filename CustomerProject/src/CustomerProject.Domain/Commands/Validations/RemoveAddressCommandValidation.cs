using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Commands.Validations
{
    public class RemoveAddressCommandValidation : AddressValidation<RemoveAddressCommand>
    {
        public RemoveAddressCommandValidation()
        {
            ValidateId();
        }
    }
}
