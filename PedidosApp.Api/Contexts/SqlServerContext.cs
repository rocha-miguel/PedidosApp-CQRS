using Microsoft.EntityFrameworkCore;
using PedidosApp.Api.Mappings;

namespace PedidosApp.Api.Contexts {
    public class SqlServerContext : DbContext {

        public SqlServerContext(DbContextOptions<SqlServerContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfiguration(new PedidoMap());
        }
    }
}
