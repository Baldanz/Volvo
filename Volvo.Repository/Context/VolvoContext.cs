using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Volvo.Domain;

namespace Volvo.Repository.Context
{
    public class VolvoContext : DbContext
    {
        #region atributos

        readonly IConfiguration _configuration;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe VolvoContext
        /// </summary>
        public VolvoContext() { }

        /// <summary>
        /// construtor da classe VolvoContext
        /// </summary>
        /// <param name="configuration">configuração de acesso aos recursos do sistema</param>
        public VolvoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region métodos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("VolvoDev"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // tabela de caminhões
            modelBuilder.Entity<CaminhaoModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.Modelo).HasColumnName("MODELO");
                    entity.Property(e => e.AnoFabricao).HasColumnName("ANO_FABRICACAO");
                    entity.Property(e => e.AnoModelo).HasColumnName("ANO_MODELO");
                    entity.ToTable("TB_VOLVO_CAMINHAO");
                }
            );
        }

        #endregion

        #region tabelas

        public DbSet<CaminhaoModel> TB_VOLVO_CAMINHAO { get; set; }

        #endregion

        #region propriedades

        public SqlConnection SqlConn => new SqlConnection(_configuration.GetConnectionString("VolvoDev"));

        #endregion
    }
}