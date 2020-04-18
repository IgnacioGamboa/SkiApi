using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkiApi.Models
{
    public class Race
    {
        public string NameOfRace { get; set; }
        public Guid Id { get; set; }


        /// <summary>
        /// List of winners and the year they won
        /// </summary>
        public List<Winner> Winners { get; set; }
    }
}
