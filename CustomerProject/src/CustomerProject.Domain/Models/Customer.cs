using CustomerProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id, string name, string email, string phone, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            AddressList = new List<Address>();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Address> AddressList { get; set; }
    }
}
