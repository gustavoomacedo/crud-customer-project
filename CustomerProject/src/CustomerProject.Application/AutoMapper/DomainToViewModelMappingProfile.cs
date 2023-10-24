using AutoMapper;
using CustomerProject.Application.ViewModels;
using CustomerProject.Domain.Models;

namespace CustomerProject.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Address, AddressViewModel>();
        }
    }
}
