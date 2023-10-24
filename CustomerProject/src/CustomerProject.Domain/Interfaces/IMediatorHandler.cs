using CustomerProject.Domain.Commands;
using CustomerProject.Domain.Models;
using FluentValidation.Results;

namespace CustomerProject.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;

        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
