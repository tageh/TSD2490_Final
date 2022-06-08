using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gruppe11.Data
{
    public class WeatherForecastService
    {

        private readonly Gruppe11Context _context;
        public WeatherForecastService(Gruppe11Context context)
        {
            _context = context;
        }
        
        /*
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }
        */

        public async Task<List<VærMelding>> GetForecastAsync(string strCurrentUser)
        {
            // Get Weather Forecasts  
            return await _context.VærMelding.Where(x => x.Bruker == strCurrentUser).AsNoTracking().ToListAsync();
        }

        public Task<VærMelding>
           CreateForecastAsync(VærMelding objWeatherForecast)
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
            var ExistingWeatherForecast =
                _context.VærMelding
                .Where(x => x.Id == objWeatherForecast.Id)
                .FirstOrDefault();
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