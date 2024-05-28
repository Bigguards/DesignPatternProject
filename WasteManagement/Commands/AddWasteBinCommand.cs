using WasteManagement.Models;
using WasteManagement.Repositories;

namespace WasteManagement.Observers
{
    public class AddWasteBinCommand
    {
        private readonly IRepository<WasteBin> _repository;
        private readonly WasteBin _wasteBin;

        public AddWasteBinCommand(IRepository<WasteBin> repository, WasteBin wasteBin)
        {
            _repository = repository;
            _wasteBin = wasteBin;
        }

        public void Execute()
        {
            _repository.Add(_wasteBin);
        }
    }
}
