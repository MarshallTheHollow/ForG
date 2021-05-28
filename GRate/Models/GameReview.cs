using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRate.Models
{
    public class GameReview
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int Rate { get; set; }
        public string Description {get;set;}
    }
}
