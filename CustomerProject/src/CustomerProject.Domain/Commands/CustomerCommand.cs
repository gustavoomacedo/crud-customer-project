using CustomerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public string Phone { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        public List<Address> Addresses { get; protected set; }
    }
}