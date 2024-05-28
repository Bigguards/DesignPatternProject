using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using WasteManagement.Models;
using WasteManagement.Observers;

namespace WasteManagement.Repositories
{
    public class RouteRepository : IRepository<WasteCollection>
    {
        private readonly ApplicationDbContext _context;

        public RouteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<WasteCollection> GetAll()
        {
            return _context.WasteCollections.Include(P => P.WasteBin).ToList();
        }

        public WasteCollection GetById(int id)
        {
            return _context.WasteCollections.Where(p => p.WasteBinId == id).FirstOrDefault() ;
        }
        public void Add(WasteCollection bin)
        {
            _context.WasteCollections.Add(bin);
            _context.SaveChanges();
        }

        public void Update(WasteBin bin)
        {
            var route = _context.WasteCollections.Find(bin);
            Update(route);
        }

        public void Update(WasteCollection entity)
        {
            _context.WasteCollections.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
