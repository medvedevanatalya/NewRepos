using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле ФИО обязательно к заполнению")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Длина строки не менее 3-х символов и не более 100")]
        [Display(Name = "ФИО")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Поле E-mail обязательно к заполнению")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "E-mail")]
        public string EmailUser { get; set; }
    }
}