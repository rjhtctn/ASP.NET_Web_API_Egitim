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