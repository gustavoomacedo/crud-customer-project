using CustomerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Commands
{
    public abstract class AddressCommand : Command
    {
        public Guid Id { get; protected set; }
        public string PostalCode { get; protected set; }
        public string Street { get; protected set; }
        public string StreetNumber { get; protected set; }
        public string ComplementaryAddress { get; protected set; }
        public string City { get; protected set; }
        public string State { get; protected set; }

        public Guid CustomerId { get; protected set; }
    }
}