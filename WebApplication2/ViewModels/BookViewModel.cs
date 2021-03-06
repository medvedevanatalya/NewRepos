﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Автор")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Поле Название книги обязательно к заполнению")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Длина строки не менее 2-х символов и не более 100")]
        [Display(Name = "Название книги")] 
        public string Title { get; set; }
        
        [Range(0, 1000, ErrorMessage = "Недопустимое количество страниц")]
        [Display(Name = "Кол-во страниц")]
        public int? Pages { get; set; }

        [Range(0, 50000, ErrorMessage = "Недопустимая цена")]
        [Display(Name = "Цена")]
        public int? Price { get; set; }

        [Display(Name = "Жанр")]
        public int GenreBookId { get; set; }

        [Display(Name = "Изображение")]
        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}