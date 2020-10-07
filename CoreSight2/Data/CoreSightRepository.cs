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
            //var table = _ctx.Readings;
            //var result = table.Where(t => t.Date > dates.From && t.Date < dates.To);

            //return result.ToList();

            return _ctx.Readings
                .Where(t => 
                t.Date > dates.From && t.Date < dates.To)
                .ToList(); ;

  
        }


        public void AddReading(Readings newReading)
        {
            // get all the items for the viewmodel and slam them into the context
            //foreach (var item in newReading.Items)
            //{
            //    item.Readings = _ctx.Readings.Find(item.Product.Id);
            //}

            AddEntity(newReading);
        }


        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
