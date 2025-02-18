using System;
using System.Threading.Tasks;
using ERPPRO.Application.Contracts;
using ERPPRO.Domain;
using ERPPRO.Persistence.Contracts;

namespace ERPPRO.Application
{
    public class EventoApplication : IEventoApplication
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IEventoPersistence _eventoPersistence;

        public EventoApplication(IGeralPersistence geralPersistence, IEventoPersistence eventoPersistence)
        {
            _geralPersistence = geralPersistence;
            _eventoPersistence = eventoPersistence;
        }


        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);
                if(await _geralPersistence.SaveChangeAsync())
                {
                    return await _eventoPersistence.GetIdEventoAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersistence.GetIdEventoAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersistence.Update(model);
                if(await _geralPersistence.SaveChangeAsync())
                {
                    return await _eventoPersistence.GetIdEventoAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersistence.GetIdEventoAsync(eventoId, false);
                if (evento == null) throw new Exception("Registro não encontrado!");

                _geralPersistence.Delete<Evento>(evento);
                return await _geralPersistence.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetIdEventoAsync(int funcionarioId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersistence.GetIdEventoAsync(funcionarioId, includePalestrantes);
                if (evento == null) return null;

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}