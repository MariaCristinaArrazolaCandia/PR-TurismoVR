using Turismo_API.Models;

namespace Turismo_API.Services.Interfaces
{
    public interface ITouristHoraryService
    {
        Task InsertHoraries(List<Horary> horaries, int id);
    }
}
