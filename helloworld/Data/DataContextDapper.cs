using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace helloworld.Data
{
    // Définition de la classe DataContextDapper
    public class DataContextDapper
    {
        // Déclaration d'une variable pour stocker la chaîne de connexion à la base de données
        private string? _connectionString;

        // Constructeur prenant IConfiguration comme argument pour injecter la configuration
        public DataContextDapper(IConfiguration config)
        {
            // Récupération de la chaîne de connexion à partir de la configuration
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        // Méthode générique pour charger des données à partir de la base de données
        public IEnumerable<T> LoadData<T>(string sql)
        {
            // Création d'une connexion à la base de données
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            // Exécution de la requête SQL et retour des résultats
            return dbConnection.Query<T>(sql);
        }

        // Méthode générique pour charger une seule ligne de données à partir de la base de données
        public T LoadDataSingle<T>(string sql)
        {
            // Création d'une connexion à la base de données
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            // Exécution de la requête SQL et retour de la première ligne de résultat
            return dbConnection.QuerySingle<T>(sql);
        }

        // Méthode pour exécuter une requête SQL qui retourne un booléen
        public bool ExecuteSql(string sql)
        {
            // Création d'une connexion à la base de données
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            // Exécution de la requête SQL et retour du résultat sous forme de booléen
            return dbConnection.Execute(sql) > 0;
        }

        // Méthode pour exécuter une requête SQL qui retourne le nombre de lignes affectées
        public int ExecuteSqlWithRowCount(string sql)
        {
            // Création d'une connexion à la base de données
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            // Exécution de la requête SQL et retour du nombre de lignes affectées
            return dbConnection.Execute(sql);
        }
    }
}