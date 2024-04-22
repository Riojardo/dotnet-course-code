using Microsoft.EntityFrameworkCore;
using helloworld.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace helloworld.Data
{
    // Définition de la classe DataContextEF qui étend DbContext
    public class DataContextEF : DbContext
    {
        // Déclaration d'une variable pour stocker la configuration de l'application
        private IConfiguration _config;

        // Constructeur prenant IConfiguration comme argument pour injecter la configuration
        public DataContextEF(IConfiguration config)
        {
            _config = config;
            // _connectionString = config.GetConnectionString("DefaultConnection");
        }

        // Déclaration du DbSet pour l'entité Computer dans la base de données
        public DbSet<Computer> Computer { get; set; }

        // Méthode pour configurer DbContextOptionsBuilder
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                // Configuration de l'option d'utilisation de SQL Server en utilisant la chaîne de connexion définie dans appsettings.json
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                    options => options.EnableRetryOnFailure());
            }
        }

        // Méthode pour configurer le modèle de données
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration du schéma par défaut du modèle de données
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            // Définition de la clé primaire de l'entité Computer
            modelBuilder.Entity<Computer>().HasKey(c => c.ComputerId);

            // Autres configurations du modèle de données (commentées)
            // .ToTable("Computer", "TutorialAppSchema");
            // .ToTable("TableName", "SchemaName");
        }
    }
}