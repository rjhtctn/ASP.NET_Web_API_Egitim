using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Entities.RequestFeatures;

namespace Repositories.EFCore
{
    public sealed class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {

        }
        public void CreateOneBook(Book book) => Create(book);
        public void DeleteOneBook(Book book) => Delete(book);  
        public async Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParemeters, 
            bool trackChanges)
        {
            var books = await FindAll(trackChanges)
                .FilterBooks(bookParemeters.MinPrice, bookParemeters.MaxPrice)
                .OrderBy(b => b.Id)
                .ToListAsync();

            return PagedList<Book>.ToPagedList(books,bookParemeters.PageNumber, bookParemeters.PageSize);
        }
        public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges) => 
            await FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        public void UpdateOneBook(Book book) => Update(book);
    }
}