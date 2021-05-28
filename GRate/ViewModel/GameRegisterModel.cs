using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GRate.ViewModel
{
    public class GameRegisterModel
    {

        [Required(ErrorMessage = "Не указано Название")]
        public string GameName { get; set; }

        [Required(ErrorMessage = "Не указано название компании")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Не указан жанр")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        public string GameDiscription { get; set; }

        [Required(ErrorMessage = "Не указано время релиза")]
        public DateTime GameReleaseTime { get; set; }

        [Required(ErrorMessage = "Не указано изображение")]
        public byte[] Image { get; set; }

    }
}
