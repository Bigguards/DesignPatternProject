using WasteManagement.Models;

namespace WasteManagement.Observers
{
    public interface IObserver
    {
        void Update(WasteBin wasteBin);
    }
}
