using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Domain;

namespace ERPPRO.Persistence.Contracts
{
    public interface IEventoPersistence
    {
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetIdEventoAsync(int eventoId, bool includePalestrantes = false);
    }
}