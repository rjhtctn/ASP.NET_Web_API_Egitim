using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;   
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService service)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, service)); 
        }
        public IBookService BookService => _bookService.Value;
    }
}