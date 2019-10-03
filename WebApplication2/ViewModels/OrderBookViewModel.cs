using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class OrderBookViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Пользователь")]
        public virtual int? UserId { get; set; }

        [Display(Name = "Книга")]
        public virtual int? BookId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата заказа")]
        public DateTime CurentDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Предварительная дата сдачи")]
        public DateTime Deadline { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата возврата")]
        public DateTime ActualReturnDate { get; set; }
    }
}