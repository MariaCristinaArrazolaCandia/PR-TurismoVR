using Turismo_API.Data;
using Turismo_API.Models;
using Turismo_API.Services.Interfaces;

namespace Turismo_API.Services
{
    public class TouristHoraryService : ITouristHoraryService
    {
        private readonly BdTurismoTiquipayaContext _context;

        public TouristHoraryService(BdTurismoTiquipayaContext context)
        {
            _context = context;
        }

        public async Task InsertHoraries(List<Horary> horaries, int id)
        {
            foreach (var h in horaries)
            {
                h.TouristSiteId = id;
                await _context.Horaries.AddAsync(h);
            }
            await _context.SaveChangesAsync();
        }
    }
}
