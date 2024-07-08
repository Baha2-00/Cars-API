using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Core.DTOs
{
    public class UpdateCarDTO
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
