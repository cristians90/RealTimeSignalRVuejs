using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using RealTimeService.Hubs;

namespace RealTimeService.Services
{
    public class FakeMessagingService : IHostedService
    {
        readonly IHubContext<MessageHub, IMessageHub> messageHubContext;

        public FakeMessagingService(IHubContext<MessageHub, IMessageHub> _messageHubContext)
        {
            messageHubContext = _messageHubContext;
        }

        async Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await SendMessage();
                await Task.Delay(5000);
            }
        }

        async Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(5000);
            }
        }

        async Task SendMessage()
        {
            // Generar numero aleatorio entre 1 y 5
            // para simular los 5 tipos de mensajes
            // definidos en IMessageHub
            switch (new Random().Next(1, 6))
            {
                case 1:
                    await messageHubContext.Clients.All.MessageFromServer("Mensaje de prueba");
                    break;
                case 2:
                    await messageHubContext.Clients.All.InfoMessageFromServer("Este es un mensaje informativo desde el servidor");
                    break;
                case 3:
                    await messageHubContext.Clients.All.SuccessMessageFromServer("El servidor responde que el proceso se realizo");
                    break;
                case 4:
                    await messageHubContext.Clients.All.WarningMessageFromServer("El sistema funciona pero con algunos inconvenintes");
                    break;
                case 5:
                    await messageHubContext.Clients.All.ErrorMessageFromServer("Hay errores de proceso dentro del servidor");
                    break;
            }

        }

    }
}
