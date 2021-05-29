using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRate.Models
{
    public class GameReview
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? GameId { get; set; }
        public Game Game { get; set; }
        public int Rate { get; set; }
        public string Description {get;set;}
    }
}
