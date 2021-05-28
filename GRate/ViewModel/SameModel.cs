using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRate.ViewModel
{
    public class SameModel
    {
        public IEnumerable<GameRegisterModel> GameRegisterModels { get; set; }
        public IEnumerable<GenreRegisterModel> GenreRegisterModels { get; set; }
    }
}
