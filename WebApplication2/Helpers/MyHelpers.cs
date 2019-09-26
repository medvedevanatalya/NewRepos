using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.ViewModels;

namespace WebApplication2.Helpers
{
    public static class MyHelpers
    {
        public static MvcHtmlString TableShow(List<OrderBookViewModel> items, string nameCssClass)
        {  
            TagBuilder table = new TagBuilder("table"); 
            table.AddCssClass(nameCssClass);
            TagBuilder header = new TagBuilder("tr");

            TagBuilder idOrderHeader = new TagBuilder("th");
            idOrderHeader.SetInnerText("Номер заказа");

            TagBuilder userHeader = new TagBuilder("th");
            userHeader.SetInnerText("Пользователь");

            TagBuilder bookHeader = new TagBuilder("th");
            bookHeader.SetInnerText("Книга");

            TagBuilder curentDateHeader = new TagBuilder("th");
            curentDateHeader.SetInnerText("Дата заказа");

            TagBuilder deadlineHeader = new TagBuilder("th");
            deadlineHeader.SetInnerText("Срок сдачи");

            TagBuilder actualReturnDateHeader = new TagBuilder("th");
            actualReturnDateHeader.SetInnerText("Дата возврата");

            header.InnerHtml += idOrderHeader.ToString();
            header.InnerHtml += userHeader.ToString();
            header.InnerHtml += bookHeader.ToString();
            header.InnerHtml += curentDateHeader.ToString();
            header.InnerHtml += deadlineHeader.ToString();
            header.InnerHtml += actualReturnDateHeader.ToString();
            table.InnerHtml += header.ToString();
          
            foreach (var item in items)
            {
                TagBuilder row = new TagBuilder("tr");

                TagBuilder idOrder = new TagBuilder("td");
                idOrder.SetInnerText((item.Id).ToString());

                TagBuilder user = new TagBuilder("td");
                user.SetInnerText((item.UserId).ToString());

                TagBuilder book = new TagBuilder("td");
                book.SetInnerText((item.BookId).ToString());

                TagBuilder curentDate = new TagBuilder("td");
                curentDate.SetInnerText((item.CurentDate).ToString());

                TagBuilder deadline = new TagBuilder("td");
                deadline.SetInnerText((item.Deadline).ToString());

                TagBuilder actualReturnDate = new TagBuilder("td");
                actualReturnDate.SetInnerText((item.ActualReturnDate).ToString());     

                row.InnerHtml += idOrder.ToString();
                row.InnerHtml += user.ToString();
                row.InnerHtml += book.ToString();
                row.InnerHtml += curentDate.ToString();
                row.InnerHtml += deadline.ToString();
                row.InnerHtml += actualReturnDate.ToString();
                table.InnerHtml += row.ToString();
            }    
            return new MvcHtmlString(table.ToString());
        }

        public static MvcHtmlString SubmitHelper(this HtmlHelper html, string textButton, string nameCssClass)
        {
            TagBuilder elem = new TagBuilder("input");

            elem.MergeAttribute("type", "submit");
            elem.MergeAttribute("value", textButton);
            elem.MergeAttribute("class", nameCssClass);                     

            return new MvcHtmlString(elem.ToString(TagRenderMode.SelfClosing));
        }
    }
}