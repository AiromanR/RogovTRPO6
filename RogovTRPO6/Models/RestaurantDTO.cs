namespace RogovTRPO6.Models
{
    public class RestaurantDTO
    {
        public string? Name { get; set; }

        public string? Cuisine { get; set; }

        public decimal? Rating { get; set; }

        public decimal? AverageCheck { get; set; }

        public bool? IsOpen { get; set; }
    }
}
