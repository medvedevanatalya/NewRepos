using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataLayer.Entities;

namespace WebApplication2.Controllers
{
    public class OrdersBooksApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/OrdersBooksApi
        public IQueryable<OrdersBooks> GetOrdersBooks()
        {
            return db.OrdersBooks;
        }

        // GET: api/OrdersBooksApi/5
        [ResponseType(typeof(OrdersBooks))]
        public IHttpActionResult GetOrdersBooks(int id)
        {
            OrdersBooks ordersBooks = db.OrdersBooks.Find(id);
            if (ordersBooks == null)
            {
                return NotFound();
            }

            return Ok(ordersBooks);
        }

        // PUT: api/OrdersBooksApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrdersBooks(int id, OrdersBooks ordersBooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ordersBooks.Id)
            {
                return BadRequest();
            }

            db.Entry(ordersBooks).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersBooksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrdersBooksApi
        [ResponseType(typeof(OrdersBooks))]
        public IHttpActionResult PostOrdersBooks(OrdersBooks ordersBooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ordersBooks.CurentDate = DateTime.Today;
            ordersBooks.ActualReturnDate = DateTime.Today;
            db.OrdersBooks.Add(ordersBooks);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ordersBooks.Id }, ordersBooks);
        }

        // DELETE: api/OrdersBooksApi/5
        [ResponseType(typeof(OrdersBooks))]
        public IHttpActionResult DeleteOrdersBooks(int id)
        {
            OrdersBooks ordersBooks = db.OrdersBooks.Find(id);
            if (ordersBooks == null)
            {
                return NotFound();
            }

            db.OrdersBooks.Remove(ordersBooks);
            db.SaveChanges();

            return Ok(ordersBooks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrdersBooksExists(int id)
        {
            return db.OrdersBooks.Count(e => e.Id == id) > 0;
        }
    }
}