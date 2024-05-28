using WasteManagement.Models;
using WasteManagement.Repositories;

namespace WasteManagement.Observers
{
    public class DeleteWasteBinCommand : ICommand
    {
        private readonly IRepository<WasteBin> _repository;
        private readonly int _id;

        public DeleteWasteBinCommand(IRepository<WasteBin> repository, int id)
        {
            _repository = repository;
            _id = id;
        }

        public void Execute()
        {
            _repository.Delete(_id);
        }
    }
}
