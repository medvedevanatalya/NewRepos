using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Users
    {

        public int Id { get; set; }

        [Required]
        public string FIO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<UsersAndBooks> UsersAndBooks { get; set; }

        public string EmailUser { get; set; }
    }
}