using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Core.DTOs
{
    public class GetCarDetailsDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public float Price { get; set; }
        public int Model { get; set; }
        public string Description { get; set; }
        public string Fuletype { get; set; }
        public string Platenumber { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime LastCheckupDate { get; set; }
        public bool IsActive { get; set; }
    }
}
