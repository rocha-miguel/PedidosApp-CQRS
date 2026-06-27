using MongoDB.Driver;
using PedidosApp.Api.Models;

namespace PedidosApp.Api.Contexts;

public class MongoDbContext {

    private readonly IConfiguration _configuration;

    public MongoDbContext(IConfiguration configuration) {

        _configuration = configuration;

        var mongoClient = new MongoClient(_configuration.GetConnectionString("MongoDB"));

        var mongoDatabase = mongoClient.GetDatabase("DbPedidos");

        Pedidos = mongoDatabase.GetCollection<Pedidos?>("pedidos");

    }

    public IMongoCollection<Pedidos?> Pedidos { get; set; }
}

