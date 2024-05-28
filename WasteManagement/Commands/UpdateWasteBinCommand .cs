using WasteManagement.Models;
using WasteManagement.Repositories;

namespace WasteManagement.Observers
{
    public class UpdateWasteBinCommand : ICommand
    {
        private readonly IRepository<WasteBin> _repository;
        private readonly WasteBin _wasteBin;

        public UpdateWasteBinCommand(IRepository<WasteBin> repository, WasteBin wasteBin)
        {
            _repository = repository;
            _wasteBin = wasteBin;
        }

        public void Execute()
        {
            _repository.Update(_wasteBin);
        }
    }
}
