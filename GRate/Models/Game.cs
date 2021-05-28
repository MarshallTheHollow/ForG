using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRate.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string CompanyName { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        public string GameDiscription{ get; set; }
        public DateTime GameReleaseTime { get; set; }
        public byte[] Image { get; set; }
    }
}
