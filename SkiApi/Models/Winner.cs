using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkiApi.Models
{
    public class Winner
    {
        public Guid RaceId { get; set; }
        public Race Race { get; set; }

        public int Year { get; set; }

        public Guid SkierId { get; set; }
        public Skier Skier { get; set; }
    }
}
