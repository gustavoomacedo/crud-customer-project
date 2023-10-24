using CustomerProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Models
{
    public class Address : Entity, IAggregateRoot
    {
        public Address(Guid id, string postalCode, string street, string streetNumber, 
                        string complementaryAddress, string city, string state, Guid customerId)
        {
            Id = id;
            PostalCode = postalCode;
            Street = street;
            StreetNumber = streetNumber;
            ComplementaryAddress = complementaryAddress;
            City = city;
            State = state;
            CustomerId = customerId;
        }

        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ComplementaryAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
