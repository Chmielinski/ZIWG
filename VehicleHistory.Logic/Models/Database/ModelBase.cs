using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleHistory.Logic.Models.Database
{
    public class ModelBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public bool Archival { get; set; } = false;
    }
}
