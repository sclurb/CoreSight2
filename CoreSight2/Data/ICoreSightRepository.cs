using CoreSight2.Data.Entities;
using CoreSight2.ViewModels;
using System;
using System.Collections.Generic;

namespace CoreSight2.Data
{
    public interface ICoreSightRepository
    {
        void AddReading(Readings newReading);
        IEnumerable<Readings> GetAllReadings();
        public IEnumerable<Readings> GetReadingsByDateRange(ChartViewModel dates);
        bool SaveAll();
        bool SaveChanges();
       // void AddReading(Readings newReading);
    }
}