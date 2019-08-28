using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class UsersAndBooks
    {
        public int Id { get; set; }

        public int? IdUser { get; set; }
        public int? IdBook { get; set; }

        public Users Users { get; set; }
        public Books Books { get; set; }
    }
}