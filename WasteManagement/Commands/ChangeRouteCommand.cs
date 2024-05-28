using WasteManagement.Models;
using WasteManagement.Observers;
using WasteManagement.Repositories;

namespace WasteManagement.Commands
{
    public class ChangeRouteCommand : ICommand
    {
        private readonly IRepository<WasteCollection> _repository;
        private readonly WasteCollection _collection;
        public ChangeRouteCommand(IRepository<WasteCollection> repository, WasteCollection collection)
        { 
            _repository = repository;
            _collection = collection;
        }
        public void Execute()
        {
            _repository.Update(_collection);
        }
    }
}
