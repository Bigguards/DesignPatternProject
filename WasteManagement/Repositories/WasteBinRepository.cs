using WasteManagement.Models;
using WasteManagement.Observers;

namespace WasteManagement.Repositories
{
    public class WasteBinRepository : IRepository<WasteBin>
    {
        private readonly ApplicationDbContext _context;
        private readonly WasteBinSubject _subject;
        private readonly IRepository<WasteCollection> _repository;
        public WasteBinRepository(ApplicationDbContext context, WasteBinSubject subject
            , IRepository<WasteCollection> repository)
        {
            _context = context;
            _subject = subject;
            _repository = repository;
        }

        public IEnumerable<WasteBin> GetAll()
        {
            return _context.WasteBins.ToList();
        }

        public WasteBin GetById(int id)
        {
            return _context.WasteBins.Find(id);
        }

        public void Add(WasteBin bin)
        {
            _context.WasteBins.Add(bin);
            _context.SaveChanges();
        }

        public void Update(WasteBin bin)
        {
            _context.WasteBins.Update(bin);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var wasteBin = _context.WasteBins.Find(id);
            if (wasteBin != null)
            {
                _context.WasteBins.Remove(wasteBin);
                _context.SaveChanges();
            }
        }
    }
}
