using System.ComponentModel.DataAnnotations; // Importation de l'espace de noms pour les annotations de validation

namespace helloworld.Models
{
    public class ComputerSnake
    {
        // Propriété représentant l'identifiant de l'ordinateur
        public int computer_id { get; set; } 

        // Propriété représentant la carte mère de l'ordinateur
        public string motherboard { get; set; }

        // Propriété représentant le nombre de cœurs du processeur de l'ordinateur (nullable)
        public int? cpu_cores { get; set; } 

        // Propriété booléenne indiquant si l'ordinateur dispose du WiFi
        public bool has_Wifi { get; set; } 

        // Propriété booléenne indiquant si l'ordinateur dispose de la LTE (4G)
        public bool has_LTE { get; set; } 

        // Propriété représentant la date de sortie de l'ordinateur
        public DateTime? release_Date { get; set; } 

        // Propriété représentant le prix de l'ordinateur
        public decimal price { get; set; } 

        // Propriété représentant la carte graphique de l'ordinateur
        public string video_card { get; set; } 

        // Constructeur de la classe Computer
        public ComputerSnake()
        {
            // Si la carte mère est nulle, elle est initialisée à une chaîne vide
            if (motherboard == null)
            {
                motherboard = "";
            }

            // Si la carte graphique est nulle, elle est initialisée à une chaîne vide
            if (video_card == null)
            {
                video_card = "";
            }

            // Si le nombre de cœurs du processeur est nul, il est initialisé à 0
            if (cpu_cores == null)
            {
                cpu_cores = 0;
            }
            
        }
    }
}