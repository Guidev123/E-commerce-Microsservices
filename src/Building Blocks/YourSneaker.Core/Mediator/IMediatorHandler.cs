using System;
using FluentValidation.Results;
using YourSneaker.Core.Messages;

namespace YourSneaker.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
