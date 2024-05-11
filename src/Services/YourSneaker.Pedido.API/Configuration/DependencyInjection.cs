using FluentValidation.Results;
using MediatR;
using YourSneaker.Core.Mediator;
using YourSneaker.Pedido.API.Application.Commands;
using YourSneaker.Pedido.API.Application.Events;
using YourSneaker.Pedido.API.Application.Queries;
using YourSneaker.Pedido.Domain.Descontos;
using YourSneaker.Pedido.Domain.Pedidos;
using YourSneaker.Pedido.Infra.Data;
using YourSneaker.Pedido.Infra.Data.Repository;
using YourSneaker.WebAPI.Core.User;

namespace YourSneaker.Pedido.API.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();


            //COMMAND AND EVENT
            services.AddScoped<IRequestHandler<AdicionarPedidoCommand, ValidationResult>, PedidoCommandHandler>();
            services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();


            // APPLICATION
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<ICupomQueries, CupomQueries>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();


            // DATA
            services.AddScoped<ICupomRepository, CupomRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<PedidosContext>();
        }
    }
}
