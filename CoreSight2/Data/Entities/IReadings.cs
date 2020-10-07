using System;

namespace CoreSight2.Data.Entities
{
    public interface IReadings
    {
        DateTime Date { get; set; }
        decimal Hum1 { get; set; }
        decimal Hum2 { get; set; }
        decimal Hum3 { get; set; }
        decimal Hum4 { get; set; }
        int Id { get; set; }
        decimal Temp1 { get; set; }
        decimal Temp2 { get; set; }
        decimal Temp3 { get; set; }
        decimal Temp4 { get; set; }
    }
}