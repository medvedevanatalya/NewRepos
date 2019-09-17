using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Genres
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string GenreName { get; set; }

        public Books Books { get; set; }
    }
}