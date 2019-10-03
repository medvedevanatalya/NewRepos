using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле Имя обязательно к заполнению")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Длина строки не менее 2-х символов и не более 100")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле Фамилия обязательно к заполнению")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Длина строки не менее 2-х символов и не более 100")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } 
    }
}