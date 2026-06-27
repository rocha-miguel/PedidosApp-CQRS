using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PedidosApp.Api.Models;

public class Pedidos {

    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string? Id { get; set; }

    [BsonElement("nome_cliente")]
    public string? NomeCliente { get; set; }

    [BsonElement("valor_pedido")]
    public decimal? Valor { get; set; }

    [BsonElement("observacoes_pedido")]
    public string? Observacoes { get; set; }

    [BsonElement("data_pedido")]
    public DateTime? DataPedido { get; set; }


    [BsonElement("data_exclusao_pedido")]
    public DateTime? DataExclusao { get; set; }


}

