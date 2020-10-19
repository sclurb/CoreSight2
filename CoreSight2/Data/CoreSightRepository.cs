using CoreSight2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSight2.ViewModels;
using CoreSight2.Data;
using System.Collections;

namespace CoreSight2.Data
{
    public class CoreSightRepository : ICoreSightRepository
    {
        private readonly CoreSightDbContext _ctx;

        public CoreSightRepository(CoreSightDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Readings> GetAllReadings()
        {
            return _ctx.Readings
                .OrderBy(p => p.Date)
                .ToList();
        }


        public IEnumerable<Readings> GetReadingsByDateRange(ChartViewModel dates)
        {
            return _ctx.Readings
                .Where(t => 
                t.Date > dates.From && t.Date < dates.To)
                .OrderBy(y => y.Date.Year)
                .ThenBy(m => m.Date.Month)
                .ThenBy(d => d.Date.Day)
                .ThenBy(h => h.Date.Hour)
                .ThenBy(m => m.Date.Minute)
                .ToList(); ;
        }
        public int AddReading(Readings newReading)
        {
            _ctx.Add(newReading);
            return SaveChanges();
        }
        public int DeleteReadingById(int Id)
        {
            var result = _ctx.Readings.FirstOrDefault(r => r.Id == Id);
            if (result != null)
            {
                _ctx.Readings.Remove(result);
            }
            return SaveChanges();
        }

        public Readings GetLatestReading()
        {
            var result = _ctx.Readings.OrderByDescending(d => d.Date).First();
            return result;
        }

        public int SaveChanges()
        {
            return _ctx.SaveChanges();
        }
    }
}
