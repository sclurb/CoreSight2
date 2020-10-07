using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreSight2.Data.Entities
{
    public class Readings : IReadings
    {

        public int Id { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Temp1 { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Temp2 { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Temp3 { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Temp4 { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Hum1 { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Hum2 { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Hum3 { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Hum4 { get; set; }
        public DateTime Date { get; set; }

        public decimal ConvertToFahrenheit(decimal value)
        {
            value = (decimal)((double)value * 1.8) + 32;
            return value;
        }

    }
}
