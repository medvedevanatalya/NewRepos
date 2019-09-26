using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class OrderBookViewModel
    {
        public int Id { get; set; }
        public virtual int? UserId { get; set; }
        public virtual int? BookId { get; set; }
        public DateTime CurentDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime ActualReturnDate { get; set; }
    }
}