using System.Threading.Tasks;
using ERPPRO.Domain;

namespace ERPPRO.Application.Contracts
{
    public interface IEventoApplication
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEventos(int eventoId, Evento model);
        Task<bool> DeleteEvento(int funcionarioId);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetIdEventoAsync(int funcionarioId, bool includePalestrantes = false);
    }
}