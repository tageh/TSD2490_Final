#nullable disable
using Microsoft.EntityFrameworkCore;
using Gruppe11.Models;

namespace Gruppe11.Data.Services
{
    public class ObservasjonService
    {
        private readonly ObservasjonContext _context;
        public ObservasjonService(ObservasjonContext context)
        {
            _context = context;
        }

        public async Task<List<Observasjon>> GetObservasjonAsync()
        {
            return await _context.Observasjon.AsNoTracking().ToListAsync();
        }

        public async Task<Observasjon> GetObservasjonByDateAsync(DateTime dato)
        {
            var observasjonsobjekt = await _context.Observasjon.FirstOrDefaultAsync(o => o.Dato.Equals(dato));
            if (observasjonsobjekt != null)
            {
                return await Task.FromResult(observasjonsobjekt);
            }
            return new Observasjon();
        }
        public async Task CreateObservasjonerAsync(List<Observasjon> observasjonsobjekter)
        {

            foreach (var observasjonsobjekt in observasjonsobjekter)
            {
                DateTime dato = (DateTime)observasjonsobjekt.Dato;
                bool erDenRegistrert = ((await GetObservasjonByDateAsync(dato)).Dato == dato) ? true : false;

                if (!erDenRegistrert)
                {
                    _context.Observasjon.Add(observasjonsobjekt);
                    _context.SaveChanges();
                }
            }

        }

    }
}
