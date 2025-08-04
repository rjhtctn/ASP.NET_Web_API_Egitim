# ASP.NET Core Web API Eğitimi

Bu depo, ASP.NET Core ile Web API geliştirme sürecinde tamamladığım eğitim bölümlerinin kısa özeti ve öğrendiğim başlıkları içerir.

---

## 1. API Temelleri   
  - API kavramı ve kullanım senaryoları  
  - HTTP protokolü (istemci-sunucu modeli, stateless yapı)  
  - RESTful prensipleri ve kaynak temelli tasarım  
  - Komut satırı ile `curl` kullanarak istek gönderme  

## 2. ASP.NET Core Altyapısı  
  - `dotnet new webapi` proje şablonu  
  - `launchSettings.json` ve ortam değişkenleri (Development/Production)  
  - Dependency Injection (servis kaydı, `builder.Services`)  
  - Swagger/OpenAPI entegrasyonu ile otomatik dokümantasyon  

## 3. Logging   
  - `ILogger<T>` ile yerleşik loglama  
  - Log seviyeleri (Information, Warning, Error …)  
  - `appsettings.json` ile log konfigürasyonu  
  - Controller içine log enjekte etme  

## 4. Modeller ile Çalışma (CRUD)    
  - POCO model sınıfları (örn. `Book`)  
  - in-memory örnekleri  
  - `[ApiController]` ve `[Route]` kullanımı  
  - GET, POST, PUT, PATCH, DELETE endpoint’leri  
  - Model validation ve HTTP status kodları  

## 5. Postman ile API Testleri   
  - Postman arayüzü ve temel kavramlar  
  - Tüm HTTP yöntemlerini (GET, POST, PUT, DELETE, PATCH) test etme  
  - Global & koleksiyon (collection) değişkenleri tanımlama  
  - Pre-request ve test script’leri yazma  
  - Random/faker fonksiyonları ile dinamik veri oluşturma  
  - Koleksiyon runner ile otomatik test çalıştırma

## 6. Entity Framework Core
  - `DbContext` tanımlama  
  - Bağlantı dizesi (connection string) konfigürasyonu  
  - EF Core Migrations: veri tabanı şema yönetimi  
  - Tip konfigürasyonu (Fluent API & Data Annotations)  
  - Inversion of Control: Repository’lerin ve `DbContext`’in DI ile kaydı  
  - Veri manipülasyonu: LINQ sorguları, ekleme, güncelleme, silme  

## 7. Katmanlı Mimari  
  - Katmanlı mimari prensipleri ve katmanların sorumlulukları  
  - **Entities** (varlık/model sınıfları)  
  - **IRepositoryBase**: generic repository arayüzü  
  - **RepositoryContext**: `DbContext`’in sarmalanması  
  - **RepositoryBase**: temel CRUD implementasyonu  
  - **BookRepository**: özel repository örneği  
  - **RepositoryManager**: birden fazla repository’i yönetme  
  - **Lazy Loading** konfigürasyonu  
  - **Service Extensions** ile servis kayıtlarının modülerleştirilmesi  
  - **Configure Repository Manager** yöntemi  
  - **IBookService** ve **IServiceManager** arayüzleri  
  - **ServiceManager** IoC kaydı ve kullanımı  
  - **Sunum Katmanı** (Presentation Layer) yapısı  
  - **RepositoryContextFactory**: context factory oluşturma    

## 8. NLog ile Gelişmiş Logging  
  - NLog kütüphanesinin tanıtımı ve avantajları  
  - **ILoggingService** arayüzü: log soyutlaması  
  - **LoggerManager** sınıfı: `ILoggerService` implementasyonu  
  - `nlog.config` ile hedef (targets) ve kural (rules) yapılandırması  
  - Mimariye NLog entegrasyonu: DI ve extension metotları  
  - Log seviyeleri ve çıktı formatlarının özelleştirilmesi

## 9. Global Hata Yönetimi  
  - Merkezi hata yakalama (Exception Middleware)  
  - Hata detayları (Error Details) DTO yapısı  
  - `UseExceptionHandler` ve özel exception handler sınıfları  
  - Try/catch bloklarını minimalize ederek temiz kod  
  - NotFoundException gibi özel exception’lar  

## 10. AutoMapper  
  - AutoMapper nedir ve kullanım amaçları  
  - Data Transfer Objects (DTO) tanımlama  
  - `MappingProfile` sınıfı ile eşlemeleri konfigüre etme  
  - DI ile AutoMapper servis kaydı (`services.AddAutoMapper(...)`)  
  - `IMapper.Map<TDestination>(source)` kullanımı  

## 11. İçerik Pazarlığı (Content Negotiation)  
  - `Accept` header ile istemci isteği yönlendirme  
  - XML Data Contract Serializer ekleme (`AddXmlDataContractSerializerFormatters()`)  
  - `[Serializable]` veya DataContract/DataMember kullanımı  
  - CSV Output Formatter ile özelleştirilmiş CSV çıktısı  
  - Built-in ve custom formatters kayıt yöntemleri  

## 12. Doğrulama (Validation)  
  - `ApiBehaviorOptions` ile otomatik model state kontrolü  
  - Service katmanının validation mantığının düzenlenmesi  
  - Sunum (Presentation) katmanında model doğrulama akışı  
  - **POST** isteklerinde `[FromBody]` ve veri anotasyonları (`[Required]`, `[Range]` vb.)  
  - **PUT** isteklerinde tam güncelleme validation senaryoları  
  - **PATCH** isteklerinde kısmi güncelleme ve JSON Patch doğrulama  
  - Global model state hatalarının standart response formatına dönüştürülmesi

## 13. Asenkron Kod  
  - `async`/`await` temelleri ve Task tabanlı programlama  
  - Repository katmanında `GetAllAsync()`, `GetByIdAsync()` gibi asenkron metotlar  
  - Servis katmanında async çağrı zinciri  
  - Controller’da `public async Task<IActionResult>` endpoint tanımlama  
  - API testlerinde async metot kullanımı ve test senaryoları  

## 14. Eylem Filtreleri (Action Filters)
  - Action Filter kavramı, ASP.NET Core pipeline'daki yeri ve amacı
  - Tekrarlı kodları önlemek için özel filtre attribute'ları oluşturma (örn. ValidationFilterAttribute)
  - Loglama işlemleri için özel bir LogFilterAttribute yazımı
  - Controller ve servis katmanlarındaki kodun filtreler yardımıyla sadeleştirilmesi  

## 15. Sayfalama (Pagination)
  - Büyük veri setlerini yönetmek için sayfalama (paging) ihtiyacı
  - İstek parametrelerini (RequestParameters) modelleme ve yönetme
  - Repository ve servis katmanlarında sayfalama mantığının uygulanması
  - PagedList<T> sınıfı ile sayfalanmış veri ve metadata'yı birlikte taşıma
  - Yanıt başlıklarına (Response Headers) sayfalama bilgisini (X-Pagination) ekleme
  - Sunum (Presentation) katmanında ve API testlerinde sayfalama kullanımı
  - CORS (Cross-Origin Resource Sharing) yapılandırması ve API'yi farklı kaynaklardan erişilebilir kılma

## 16. Filtreleme (Filtering)
  - Dinamik filtreleme kavramı
  - Sayfalama parametrelerini genişleterek filtreleme kriterleri ekleme (örn. BookParameters)
  - Geçersiz filtre aralıkları için özel hata fırlatma ve merkezi yönetim (Bad Request Exception)
  - Repository katmanında IQueryable kullanarak dinamik Where koşulları ile filtre uygulama
  - Filtreleme mantığını soyutlamak için Repository extension metotları yazma
  - Postman ile filtreleme testi

## 17. Arama (Searching)
  - Metin tabanlı arama (searching) ve API'lerdeki rolü
  - İstek parametrelerine arama terimi (searchTerm) ekleme
  - Repository katmanında string.Contains() gibi metotlarla dinamik arama yapma
  - Büyük/küçük harf duyarlılığını (case sensitivity) yönetme
  - Arama mantığını soyutlamak ve yeniden kullanılabilir kılmak için Repository extension metotları tasarlama
  - Postman ile arama senaryolarının test edilmesi

## 18. Sıralama (Sorting)
  - Query string üzerinden dinamik sıralama (sorting) yapma ihtiyacı
  - System.Linq.Dynamic.Core kütüphanesi ile metin tabanlı LINQ sorguları oluşturma
  - Sıralama parametrelerini (orderBy=fieldName asc, ...) ayrıştıran ve doğrulayan bir yardımcı (OrderQueryBuilder) sınıfı geliştirme
  - IQueryable<T> üzerinde çalışan yeniden kullanılabilir bir Sort extension metodu yazma
  - Postman ile tekli ve çoklu alanlara göre sıralama senaryolarının test edilmesi

## 19. Veri Şekillendirme (Data Shaping)
  - Veri şekillendirme (Data Shaping) nedir ve API performansına etkileri
  - İstemcinin fields query string parametresi ile sadece istediği alanları talep etmesi
  - IDataShaper<T> ve DataShaper<T> implementasyonu ile veri şekillendirme mantığını tasarlama
  - Reflection (PropertyInfo) kullanarak nesne özelliklerine çalışma zamanında (runtime) erişme
  - ExpandoObject ile dinamik tipler oluşturma ve yanıt nesnesini şekillendirme
  - IDataShaper servisinin Dependency Injection (DI) ile kaydedilmesi
  - Postman ile farklı fields kombinasyonlarını test etme

	

