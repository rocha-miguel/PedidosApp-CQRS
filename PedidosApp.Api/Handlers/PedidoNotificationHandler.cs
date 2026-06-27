using MediatR;
using MongoDB.Driver;
using PedidosApp.Api.Contexts;
using PedidosApp.Api.Models;
using PedidosApp.Api.Notifications;

namespace PedidosApp.Api.Handlers;

public class PedidoNotificationHandler : INotificationHandler<PedidoNotification> {

    private readonly MongoDbContext _mongoDbContext;

    public PedidoNotificationHandler(MongoDbContext mongoDbContext) {
        _mongoDbContext = mongoDbContext;
    }

    public async Task Handle(PedidoNotification notification, CancellationToken cancellationToken) {

        var pedidos = notification.Pedidos;


        switch (notification.Action) {

            case ActionNotification.PedidoCriado:

                if (pedidos is null)
                    break;

                await _mongoDbContext.Pedidos.InsertOneAsync(pedidos);
                break;

            case ActionNotification.PedidoAlterado:

                if (pedidos is null)
                    break;


                var update = Builders<Pedidos>.Filter.Eq(p => p.Id, pedidos.Id);
                await _mongoDbContext.Pedidos.ReplaceOneAsync(update, pedidos);
                break;

            case ActionNotification.PedidoExcluído:

                if (pedidos is null)
                    break;

                var delete = Builders<Pedidos>.Filter.Eq(p => p.Id, pedidos.Id);
                await _mongoDbContext.Pedidos.DeleteOneAsync(delete);
                break;


        }

    }
}

