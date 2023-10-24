using CustomerProject.Domain.Interfaces;
using CustomerProject.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace CustomerProject.Domain.Commands
{
    public class AddressCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewAddressCommand, ValidationResult>,
        IRequestHandler<UpdateAddressCommand, ValidationResult>,
        IRequestHandler<RemoveAddressCommand, ValidationResult>
    {
        private readonly IAddressRepository _AddressRepository;

        public AddressCommandHandler(IAddressRepository AddressRepository)
        {
            _AddressRepository = AddressRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewAddressCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var Address = new Address(message.Id, message.PostalCode, message.Street, message.StreetNumber, message.ComplementaryAddress, 
                                            message.City, message.State, message.CustomerId);

            _AddressRepository.Add(Address);

            return await Commit(_AddressRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateAddressCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var address = new Address(message.Id, message.PostalCode, message.Street, message.StreetNumber, message.ComplementaryAddress, 
                                        message.City, message.State, message.CustomerId);

            _AddressRepository.Update(address);

            return await Commit(_AddressRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveAddressCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var addressess = await _AddressRepository.GetByCustomerId(message.CustomerId);

            if (addressess == null || addressess.Count() == 0)
            {
                AddError("Address doesn't exists.");
                return ValidationResult;
            }
            else
            {
                foreach (var address in addressess)
                    _AddressRepository.Remove(address);
            }

            return await Commit(_AddressRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _AddressRepository.Dispose();
        }
    }
}
