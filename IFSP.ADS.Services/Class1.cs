using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;

namespace IFSP.ADS.Services
{
    public class AtlheteService
    {
        private readonly LusaContext _db;

        public AtlheteService()
        {
            _db = new LusaContext();
        }

        public Athlete Get(int id)
        {

            //_db.Athlete.first
            return new Athlete();
        }

    }
}
