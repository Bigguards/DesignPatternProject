using System.Reflection.Metadata.Ecma335;
using WasteManagement.Commands;
using WasteManagement.Models;
using WasteManagement.Observers;
using WasteManagement.Repositories;

namespace WasteManagement.Facade
{
    public class WasteManagementFacade
    {
        private readonly IRepository<WasteBin> _repository;
        private readonly IRepository<WasteCollection> _routerepository;
        private readonly WasteBinSubject _subject;

        public WasteManagementFacade(IRepository<WasteBin> repository,
            IRepository<WasteCollection> routerepository, WasteBinSubject subject)
        {
            _repository = repository;
            _subject = subject;
            _routerepository = routerepository;
        }

        public IEnumerable<WasteBin> GetAllWasteBins()
        {
            return _repository.GetAll();
        }
        public IEnumerable<WasteCollection> GetRoutes()
        {
            return _routerepository.GetAll();
        }
        public WasteBin GetWasteBinById(int id)
        {
            return _repository.GetById(id);
        }
        public WasteCollection GetCollection(int id)
        {
            return _routerepository.GetById(id);
        }
        public void AddWasteBin(WasteBin wasteBin)
        {
            var command = new AddWasteBinCommand(_repository, wasteBin);
            command.Execute();
            _subject.Notify(wasteBin, _routerepository);
        }

        public void UpdateWasteBin(WasteBin wasteBin)
        {
            var command = new UpdateWasteBinCommand(_repository, wasteBin);
            command.Execute();
            _subject.Notify(wasteBin, _routerepository);
        }

        public void DeleteWasteBin(int id)
        {
            var command = new DeleteWasteBinCommand(_repository, id);
            command.Execute();
            var wasteBin = _repository.GetById(id);
            _subject.Notify(wasteBin, _routerepository);
        }
        
        public void UpdateRoute(int id)
        {
            var route = _routerepository.GetById(id);
            var command = new ChangeRouteCommand(_routerepository, route);
            command.Execute();
            _subject.Notify(_repository.GetById(id), _routerepository);
        }
    }
}
