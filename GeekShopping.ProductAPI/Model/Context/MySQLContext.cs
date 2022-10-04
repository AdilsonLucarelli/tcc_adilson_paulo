using Microsoft.EntityFrameworkCore;

namespace API_Gasolina.GasolinaAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Registro_cotacao> Registro { get; set; }
    }
}
