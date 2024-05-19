using MediatR;
using FluentValidation.Results;
using YourSneaker.Clientes.API.Aplication.Commands;
using YourSneaker.Core.Mediator;
using YourSneaker.Clientes.API.Models;
using YourSneaker.Clientes.API.Data.Repository;
using YourSneaker.Clientes.API.Data;
using YourSneaker.Clientes.API.Aplication.Events;
using YourSneaker.Clientes.API.Services;
using YourSneaker.WebAPI.Core.User;

namespace YourSneaker.Clientes.API.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarEnderecoCommand, ValidationResult>, ClienteCommandHandler>();

            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ClientesContext>();
        }
    }
}
