using AutoMapper;
using CustomerProject.Application.ViewModels;
using CustomerProject.Domain.Commands;

namespace CustomerProject.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.Phone, c.BirthDate));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.Phone, c.BirthDate));
            CreateMap<AddressViewModel, RegisterNewAddressCommand>()
                .ConstructUsing(c => new RegisterNewAddressCommand(c.PostalCode, c.Street, c.StreetNumber, c.ComplementaryAddress, c.City, c.State, c.CustomerId));
            CreateMap<AddressViewModel, UpdateAddressCommand>()
                .ConstructUsing(c => new UpdateAddressCommand(c.Id, c.PostalCode, c.Street, c.StreetNumber, c.ComplementaryAddress, c.City, c.State, c.CustomerId));
        }
    }
}
