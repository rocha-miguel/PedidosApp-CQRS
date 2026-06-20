using MediatR;

namespace PedidosApp.Api.Commands {
    public class PedidoDeleteCommand : IRequest {

        public Guid Id { get; set; }
    }
}
