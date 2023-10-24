using CustomerProject.Domain.Interfaces;
using CustomerProject.Domain.Models;
using CustomerProject.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject.Infra.Repository
{
    public class AddressRepository : IAddressRepository
    {
        protected readonly CustomerContext Db;
        protected readonly DbSet<Address> DbSet;

        public AddressRepository(CustomerContext context)
        {
            Db = context;
            DbSet = Db.Set<Address>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Add(Address address)
        {
            DbSet.Add(address);
        }

        public async Task<IEnumerable<Address>> GetByCustomerId(Guid customerId)
        {
            return await DbSet.AsNoTracking().Where(c =>c.CustomerId == customerId).ToListAsync();
        }

        public async Task<Address> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Remove(Address address)
        {
            DbSet.Remove(address);
        }

        public void Update(Address address)
        {
            DbSet.Update(address);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
