using AutoMapper;
using CustomerProject.Application.Interfaces;
using CustomerProject.Application.ViewModels;
using CustomerProject.Domain.Commands;
using CustomerProject.Domain.Interfaces;
using FluentValidation.Results;

namespace CustomerProject.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMediatorHandler _mediator;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IAddressRepository addressRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAll());
        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {
            var customerDB = await _customerRepository.GetById(id);
            return _mapper.Map<CustomerViewModel>(customerDB);
        }

        public async Task<AddressViewModel> GetAddressById(Guid id)
        {
            return _mapper.Map<AddressViewModel>(await _addressRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            var resultCommand = await _mediator.SendCommand(registerCommand);

            try
            {
                if (resultCommand.Errors.Count == 0 && customerViewModel.AddressList != null &&
                    customerViewModel.AddressList.Count > 0)
                {
                    foreach (var address in customerViewModel.AddressList.Select(x =>
                                new RegisterNewAddressCommand(
                                    x.PostalCode,
                                    x.Street,
                                    x.StreetNumber,
                                    x.ComplementaryAddress,
                                    x.City,
                                    x.State,
                                    registerCommand.Id)
                    )
                    .ToList())
                    {
                        var addressCommand = _mapper.Map<RegisterNewAddressCommand>(address);
                        await _mediator.SendCommand(addressCommand);
                    }
                }
            }
            catch (Exception e)
            {
                resultCommand.Errors.Add(new ValidationFailure("Exception", e.Message));
            }

            return resultCommand;
        }

        public async Task<ValidationResult> Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            var resultCommand = await _mediator.SendCommand(updateCommand);

            try
            {
                if (resultCommand.Errors.Count == 0 && customerViewModel.AddressList != null &&
                    customerViewModel.AddressList.Count > 0)
                {
                    foreach (var addressCommand in customerViewModel.AddressList.Select(x =>
                                new UpdateAddressCommand(
                                    x.Id,
                                    x.PostalCode,
                                    x.Street,
                                    x.StreetNumber,
                                    x.ComplementaryAddress,
                                    x.City,
                                    x.State,
                                    updateCommand.Id)
                    )
                    .ToList())
                    {
                        var addressVM = await GetAddressById(addressCommand.Id);
                        if (addressVM != null)
                        {
                            var addressMP = _mapper.Map<UpdateAddressCommand>(addressCommand);
                            var resultAdrress = await _mediator.SendCommand(addressMP);
                            resultCommand.Errors.AddRange(resultAdrress.Errors);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                resultCommand.Errors.Add(new ValidationFailure("Exception", e.Message));
            }

            return resultCommand;
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var result = new ValidationResult();

            try
            {
                var removeAddressCommand = new RemoveAddressCommand(id);
                var resultAddress = await _mediator.SendCommand(removeAddressCommand);

                result.Errors.AddRange(resultAddress.Errors);

                var removeCommand = new RemoveCustomerCommand(id);
                var resultCustomer = await _mediator.SendCommand(removeCommand);

                result.Errors.AddRange(resultCustomer.Errors);

            }
            catch (Exception e)
            {
                result.Errors.Add(new ValidationFailure("Exception", e.Message));
            }

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
