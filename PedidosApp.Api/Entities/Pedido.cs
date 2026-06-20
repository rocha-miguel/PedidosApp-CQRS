namespace PedidosApp.Api.Entities {
    public class Pedido {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string NomeCliente { get; set; } = string.Empty;

        public DateTime DataPedido { get; set; } = DateTime.Now;

        public DateTime? DataExclusao { get; set; }

        public decimal Valor { get; set; } = decimal.Zero;

        public string Observacoes { get; set; } = string.Empty;


    }
}
