using Microsoft.EntityFrameworkCore;
using Gruppe11.Models;

namespace Gruppe11.Data.Services
{
    public class WeatherForecastService
    {
        private readonly Gruppe11Context _context;
        public WeatherForecastService(Gruppe11Context context)
        {
            _context = context;
        }

        public async Task<List<V�rMelding>> GetForecastAsync(string strCurrentUser)
        {
            return await _context.V�rMelding.Where(x => x.Bruker == strCurrentUser).AsNoTracking().ToListAsync();
        }

        public Task<V�rMelding> CreateForecastAsync(V�rMelding objWeatherForecast)
        {
            _context.V�rMelding.Add(objWeatherForecast);
            _context.SaveChanges();
            return Task.FromResult(objWeatherForecast);
        }

        public Task<bool> UpdateForecastAsync(V�rMelding objWeatherForecast)
        {
            var ExistingWeatherForecast = _context.V�rMelding.Where(x => x.Id == objWeatherForecast.Id).FirstOrDefault();

            if (ExistingWeatherForecast != null)
            {
                ExistingWeatherForecast.Dato = objWeatherForecast.Dato;
                ExistingWeatherForecast.Kommentar = objWeatherForecast.Kommentar;
                ExistingWeatherForecast.Temperatur = objWeatherForecast.Temperatur;

                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool> DeleteForecastAsync(V�rMelding objWeatherForecast)
        {
            var ExistingWeatherForecast = _context.V�rMelding.Where(x => x.Id == objWeatherForecast.Id).FirstOrDefault();

            if (ExistingWeatherForecast != null)
            {
                _context.V�rMelding.Remove(ExistingWeatherForecast);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}