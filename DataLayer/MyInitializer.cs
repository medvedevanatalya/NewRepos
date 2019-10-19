using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataLayer.Entities;

namespace DataLayer
{
    public class MyInitializer: CreateDatabaseIfNotExists<Model1>
    {
        protected override void Seed(Model1 context)
        {
            List<Authors> authors = new List<Authors>();
            authors.Add(new Authors { Id = 1, LastName = "AuhorLastName1", FirstName = "AuthorFirstName1" });
            authors.Add(new Authors { Id = 2, LastName = "AuhorLastName2", FirstName = "AuthorFirstName2" });
            context.Authors.AddRange(authors);

            List<GenresBooks> genres = new List<GenresBooks>();
            genres.Add(new GenresBooks { Id = 1, NameGenre = "genre1" });
            genres.Add(new GenresBooks { Id = 2, NameGenre = "genre2" });
            context.GenresBooks.AddRange(genres);

            List<Users> users = new List<Users>();
            users.Add(new Users { FIO = "User1" });
            users.Add(new Users { FIO = "User2" });
            context.Users.AddRange(users);

            List<Books> books = new List<Books>();
            books.Add(new Books { AuthorId = 1, GenreBookId = 1, Pages = 250, Price = 250, Title = "Book1" });
            books.Add(new Books { AuthorId = 2, GenreBookId = 2, Pages = 350, Price = 350, Title = "Book2" });
            context.Books.AddRange(books);

            base.Seed(context);
        }
    }
}
