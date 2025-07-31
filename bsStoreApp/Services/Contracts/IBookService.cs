using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges);
        Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges);
        Task<BookDto> CreateOneBookAsync(BookDtoForInsertion book);
        Task UpdateOneBookAsync(int id, BookDtoForUptade bookDto, bool trackChanges);
        Task DeleteOneBookAsync(int id, bool trackChanges);
        Task<(BookDtoForUptade bookDtoForUptade, Book book)> GetOnBookForPatchAsync(int id, bool trackChanges);
        Task SaveChangesForPatchAsync(BookDtoForUptade bookDtoForupdate, Book book);
    }
}