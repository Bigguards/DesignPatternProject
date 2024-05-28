using WasteManagement.Models;
using WasteManagement.Repositories;

namespace WasteManagement.Observers
{
    public class WasteStateObserver : IObserver
    {
        public IRepository<WasteCollection> _repository { get; set; }
        public WasteStateObserver(IRepository<WasteCollection> repository) { _repository = repository; }
        public void Update(WasteBin wasteBin)
        {
            if (wasteBin.FillLevel > 80)
            {
                Console.WriteLine($"Warning: WasteBin {wasteBin.Id} at {wasteBin.Location} is over 80% full.");
                _repository.Add(new WasteCollection() 
                { 
                    WasteBinId = wasteBin.Id, 
                    CollectionTime = DateTime.Now
                });
            }
        }
    }
}
