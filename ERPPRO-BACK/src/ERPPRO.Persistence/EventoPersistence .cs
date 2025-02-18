using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Domain;
using ERPPRO.Persistence.Contracts;
using ERPPRO.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;

namespace ERPPRO.Persistence
{
    public class EventoPersistence : IEventoPersistence
    {
        private readonly ERPPROContext _context;
        public EventoPersistence(ERPPROContext context)
        {
            _context = context;
        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id);
            return await query.AsNoTracking().ToArrayAsync();
        }
        public async Task<Evento> GetIdEventoAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Id == eventoId);
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}