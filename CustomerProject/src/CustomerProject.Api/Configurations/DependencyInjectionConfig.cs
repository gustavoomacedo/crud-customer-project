using System;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CustomerProject.Application.Interfaces;
using CustomerProject.Application.Services;
using CustomerProject.Domain.Commands;
using CustomerProject.Domain.Interfaces;
using CustomerProject.Infra.Context;
using CustomerProject.Infra.Repository;

namespace CustomerProject.Services.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Commands
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, ValidationResult>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewAddressCommand, ValidationResult>, AddressCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAddressCommand, ValidationResult>, AddressCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveAddressCommand, ValidationResult>, AddressCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<CustomerContext>();
        }
    }
}