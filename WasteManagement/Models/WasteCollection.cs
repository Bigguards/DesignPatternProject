namespace WasteManagement.Models
{
    public class WasteCollection
    {
        public int Id { get; set; }
        public int WasteBinId { get; set; }
        public DateTime CollectionTime { get; set; }
        public WasteBin? WasteBin { get; set; }
    }
}
