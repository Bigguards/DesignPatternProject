namespace WasteManagement.Models
{
    public class WasteBin
    {
        public int Id { get; set; }
        public string? Location { get; set; }
        public double FillLevel { get; set; } // Percentage of fill level
    }
}
