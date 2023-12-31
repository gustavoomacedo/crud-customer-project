﻿using CustomerProject.Application.ViewModels;
using FluentValidation.Results;

namespace CustomerProject.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        Task<IEnumerable<CustomerViewModel>> GetAll();
        Task<CustomerViewModel> GetById(Guid id);

        Task<ValidationResult> Register(CustomerViewModel customerViewModel);
        Task<ValidationResult> Update(CustomerViewModel customerViewModel);
        Task<ValidationResult> Remove(Guid id);

    }
}
