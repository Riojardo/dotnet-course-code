using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Importation de l'espace de noms pour les annotations de validation

namespace helloworld.Models
{
    public class Computer
    {
        [JsonPropertyName("computer_id")]
        // Propriété représentant l'identifiant de l'ordinateur
        public int ComputerId { get; set; }
        
        [JsonPropertyName("motherboard")]
        // Propriété représentant la carte mère de l'ordinateur
        public string Motherboard { get; set; }
        
        [JsonPropertyName("cpu_cores")]
        // Propriété représentant le nombre de cœurs du processeur de l'ordinateur (nullable)
        public int? CPUCores { get; set; }
        
        [JsonPropertyName("has_wifi")]
        // Propriété booléenne indiquant si l'ordinateur dispose du WiFi
        public bool HasWifi { get; set; }
        
        [JsonPropertyName("has_lte")]
        // Propriété booléenne indiquant si l'ordinateur dispose de la LTE (4G)
        public bool HasLTE { get; set; }
        
        [JsonPropertyName("release_date")]
        // Propriété représentant la date de sortie de l'ordinateur
        public DateTime? ReleaseDate { get; set; }
        
        [JsonPropertyName("price")]
        // Propriété représentant le prix de l'ordinateur
        public decimal Price { get; set; }
        
        [JsonPropertyName("video_card")]
        // Propriété représentant la carte graphique de l'ordinateur
        public string VideoCard { get; set; }

        // Constructeur de la classe Computer
        public Computer()
        {
            // Si la carte mère est nulle, elle est initialisée à une chaîne vide
            if (Motherboard == null)
            {
                Motherboard = "";
            }

            // Si la carte graphique est nulle, elle est initialisée à une chaîne vide
            if (VideoCard == null)
            {
                VideoCard = "";
            }

            // Si le nombre de cœurs du processeur est nul, il est initialisé à 0
            if (CPUCores == null)
            {
                CPUCores = 0;
            }

        }
    }
}