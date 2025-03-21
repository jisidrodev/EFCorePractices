using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleAppEFCore
{
    public static class Commands
    {

        public static void ListAll()
        {
            using (AppDBContext dBContext = new AppDBContext())
            {
                foreach (var book in dBContext.Books.AsTracking().Include(book => book.Author))
                {
                    var webUrl = book.Author.WebUrl == null
                ? "- no web URL given -"
                : book.Author.WebUrl;
                    Console.WriteLine(
                        $"{book.Title} by {book.Author.Name}");
                    Console.WriteLine("     " +
                        "Published on " +
                        $"{book.AvailableFrom:dd-MMM-yyyy}" +
                        $". {webUrl}");
                }
            }
        }

        public static void ChangeWebUrl()
        {
            Console.Write("New Quantum Networking WebUrl > ");
            var newWebUrl = Console.ReadLine();

            using (var db = new AppDBContext())
            {
                var singleBook = db.Books
                    .Include(book => book.Author)
                    .Single(book => book.Title == "Quantum Networking");

                singleBook.Author.WebUrl = newWebUrl;
                db.SaveChanges();
                Console.WriteLine("... SavedChanges called.");
            }
            ListAll();
        }

    }
}
