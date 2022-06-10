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

        public async Task<List<VærMelding>> GetForecastAsync(string strCurrentUser)
        {
            return await _context.VærMelding.Where(x => x.Bruker == strCurrentUser).AsNoTracking().ToListAsync();
        }

        public Task<VærMelding> CreateForecastAsync(VærMelding objWeatherForecast)
        {
            _context.VærMelding.Add(objWeatherForecast);
            _context.SaveChanges();
            return Task.FromResult(objWeatherForecast);
        }

        public Task<bool> UpdateForecastAsync(VærMelding objWeatherForecast)
        {
            var ExistingWeatherForecast = _context.VærMelding.Where(x => x.Id == objWeatherForecast.Id).FirstOrDefault();

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

        public Task<bool> DeleteForecastAsync(VærMelding objWeatherForecast)
        {
            var ExistingWeatherForecast = _context.VærMelding.Where(x => x.Id == objWeatherForecast.Id).FirstOrDefault();

            if (ExistingWeatherForecast != null)
            {
                _context.VærMelding.Remove(ExistingWeatherForecast);
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