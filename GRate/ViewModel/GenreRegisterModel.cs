using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GRate.ViewModel
{
    public class GenreRegisterModel
    {
        [Required(ErrorMessage = "Не указано Название")]
        public string Name { get; set; }
    }
}
