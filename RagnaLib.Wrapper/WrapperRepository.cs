using System.Collections.Generic;
using RagnaLib.Domain.Entities;
using RagnaLib.Infra.Data;


namespace RagnaLib.Wrapper
{
    public class WrapperRepository
    {
        private readonly Context _context;
        
        public WrapperRepository(Context context)
        {
            _context = context;
        }

        public void CreateLocationRange(List<Location> locations)
        {
            _context.Locations.AddRange(locations);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}