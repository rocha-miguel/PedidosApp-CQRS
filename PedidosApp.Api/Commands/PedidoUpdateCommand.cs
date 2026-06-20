using MediatR;

namespace PedidosApp.Api.Commands {
    public class PedidoUpdateCommand : IRequest{

        public Guid Id { get; set; }

        public string? NomeCliente { get; set; }

        public decimal? Valor { get; set; }

        public string? Observacoes { get; set; }
    }
}