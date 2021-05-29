using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRate.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Game> Games { get; set; }
        public Genre()
        {
            Games = new List<Game>();
        }
    }
}
