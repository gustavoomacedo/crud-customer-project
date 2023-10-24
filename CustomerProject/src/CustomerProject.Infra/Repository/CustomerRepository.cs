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
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly CustomerContext Db;
        protected readonly DbSet<Customer> DbSet;

        public CustomerRepository(CustomerContext context)
        {
            Db = context;
            DbSet = Db.Set<Customer>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Customer> GetById(Guid id)
        {
            return await Db.Customers.Where(c => c.Id == id).Include(c => c.AddressList).FirstAsync();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await Db.Customers.Include(c => c.AddressList).ToListAsync();
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }

        public void Add(Customer customer)
        {
            DbSet.Add(customer);
        }

        public void Update(Customer customer)
        {
            DbSet.Update(customer);
        }

        public void Remove(Customer customer)
        {
            DbSet.Remove(customer);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
