using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDto)
        {
            var entity = _mapper.Map<Book>(bookDto);
            _manager.Book.CreateOneBook(entity);
            await _manager.SaveAsync();
            return _mapper.Map<BookDto>(entity);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);
            if (entity == null) 
            {
                throw new BookNotFoundException(id);        
            }
            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _manager.Book.GetAllBooksAsync(trackChanges);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<(BookDtoForUptade bookDtoForUptade, Book book)> 
            GetOnBookForPatchAsync(int id, bool trackChanges)
        {
            var book = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);
            if (book == null)
            {
                throw new BookNotFoundException(id);
            }
            var bookDtoForUpdate = _mapper.Map<BookDtoForUptade>(book);
            return (bookDtoForUpdate, book);
        }

        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var book = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);
            if (book == null) {
                throw new BookNotFoundException(id);
            }
            return _mapper.Map<BookDto>(book);
        }

        public async Task SaveChangesForPatchAsync(BookDtoForUptade bookDtoForupdate, Book book)
        {
            _mapper.Map(bookDtoForupdate, book);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneBookAsync(int id, 
            BookDtoForUptade bookDto, 
            bool trackChanges)
        {
            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);
            if (entity == null)
            {
                throw new BookNotFoundException(id);
            }
            entity = _mapper.Map<Book>(bookDto);
            _manager.Book.Update(entity);
            await _manager.SaveAsync();
        }
    }
}