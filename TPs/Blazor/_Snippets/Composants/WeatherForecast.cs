    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [Range(-50,50,ErrorMessage ="Valeur entre -50 et 50")]
        public int Temperature { get; set; }
        [Required(ErrorMessage ="Entrez une ville")]
        public string? Ville { get; set; }
    }