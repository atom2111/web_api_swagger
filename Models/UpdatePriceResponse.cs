namespace WebApiLessons.Models
{
    public class UpdatePriceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public decimal NewPrice { get; set; }
    }
}
