using CoreSight2.Data.Entities;
using CoreSight2.ViewModels;
using System;
using System.Collections.Generic;

namespace CoreSight2.Data
{
    public interface ICoreSightRepository
    {
        int DeleteReadingById(int Id);
        int AddReading(Readings newReading);
        IEnumerable<Readings> GetAllReadings();
        public IEnumerable<Readings> GetReadingsByDateRange(ChartViewModel dates);
        public Readings GetLatestReading();
        int SaveChanges();
    }
}