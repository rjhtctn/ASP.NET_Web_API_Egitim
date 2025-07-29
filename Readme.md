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
