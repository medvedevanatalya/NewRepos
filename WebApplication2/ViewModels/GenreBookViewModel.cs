using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class GenreBookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле Название жанра обязательно к заполнению")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Длина строки не менее 3-х символов и не более 100")]
        [Display(Name = "Название жанра")]
        public string NameGenre { get; set; }
    }
}