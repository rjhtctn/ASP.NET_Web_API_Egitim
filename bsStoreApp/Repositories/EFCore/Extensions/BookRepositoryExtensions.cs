using Entities.Models;

namespace Repositories.EFCore.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books,
            uint minPrice, uint maxPrice) =>
            books.Where(book => book.Price >= minPrice && book.Price <= maxPrice);

        public static IQueryable<Book> Search(this IQueryable<Book> books,
            string SearchTerm)
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                return books;
            }
            var lowerCaseTerm = SearchTerm.Trim().ToLower();
            return books.Where(b => b.Title.ToLower().Contains(SearchTerm));
        }
    }
}