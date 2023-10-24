using CustomerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Domain.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetById(Guid id);
        Task<IEnumerable<Address>> GetByCustomerId(Guid customerId);
        void Add(Address address);
        void Update(Address address);
        void Remove(Address address);
    }
}
