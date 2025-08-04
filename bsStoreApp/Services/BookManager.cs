using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<BookDto> _shaper;
        public BookManager(IRepositoryManager manager, 
            ILoggerService logger, 
            IMapper mapper, 
            IDataShaper<BookDto> shaper)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
            _shaper = shaper;
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
            var entity = await GetOneBookByIdAndCheckExist(id, trackChanges);
            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<ExpandoObject> books, MetaData metaData)> 
            GetAllBooksAsync(BookParameters bookParameters, 
            bool trackChanges)
        {
            if (!bookParameters.ValidPriceRange)
            {
                throw new PriceOutOfRangeBadRequestException();
            }
            var booksWithMetaData = await _manager.Book.GetAllBooksAsync(bookParameters, trackChanges);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
            var shapedData = _shaper.ShapeData(booksDto, bookParameters.Fields);
            return (books: shapedData, metaData: booksWithMetaData.Metadata);
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
            var book = await GetOneBookByIdAndCheckExist(id, trackChanges);
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
            var entity = await GetOneBookByIdAndCheckExist(id, trackChanges);
            entity = _mapper.Map<Book>(bookDto);
            _manager.Book.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Book> GetOneBookByIdAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);
            if (entity == null)
            {
                throw new BookNotFoundException(id);
            }
            return entity;
        }
    }
}