using WasteManagement.Models;
using WasteManagement.Repositories;

namespace WasteManagement.Observers
{
    public class WasteBinSubject
    {
        private List<IObserver> _observers = new List<IObserver>();

        public WasteBinSubject() {}

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(WasteBin wasteBin, IRepository<WasteCollection> repository)
        {
            if (_observers.Count == 0)
                _observers.Add(new WasteStateObserver(repository));
            foreach (var observer in _observers)
            {
                observer.Update(wasteBin);
            }
        }
    }
}
