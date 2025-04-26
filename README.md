# NLayerDotnet Projesi

## 📚 Genel Bakış
Bu proje, **.NET 8 Web API** teknolojisi kullanılarak geliştirilen, küçük ölçekli ama en iyi uygulamaları barındıran bir **N-Katmanlı Mimari (N-Layered Architecture)** örneğidir.  
Proje, **Product** ve **Category** olmak üzere iki temel entity'den oluşmakta ve aşağıdaki yazılım desenlerini ve yapılarını içermektedir:

- Repository Pattern
- Unit of Work Pattern
- Options Pattern
- Result Pattern
- FluentValidation ile Validasyon
- AutoMapper ile Nesne Dönüştürme

---

## 🛠️ Kullanılan Teknolojiler

- **ASP.NET Core 8 Web API**
- **Entity Framework Core**
- **AutoMapper**
- **FluentValidation**
- **SQL Server**
- **Options Pattern (IOptions)**
- **Repository ve Unit of Work Pattern**
- **Özelleştirilmiş Result Pattern**

---

## 🚀 Projeyi Çalıştırmak İçin

1. Depoyu klonlayın:
   ```bash
   git clone https://github.com/YildirimogCod/NLayerDotnet.git
   ```

2. Proje dizinine girin:
   ```bash
   cd NLayerDotnet
   ```

3. `appsettings.Development.json` dosyasında kendi SQL Server bağlantı bilginizi güncelleyin.

4. Migration işlemlerini uygulayın:
   ```bash
   Update-Database
   ```

5. Projeyi çalıştırın:
   ```bash
   dotnet run --project WebAPI
   ```

---

## 📌 Öne Çıkan Özellikler

- **Repository Pattern** ile veri erişimi soyutlanmıştır.
- **Unit of Work Pattern** ile işlemler bir bütün halinde yönetilmektedir.
- **Options Pattern** kullanılarak yapılandırma ayarları yönetilmektedir.
- **Result Pattern** ile tüm API yanıtlarında standart bir format sağlanmıştır.
- **FluentValidation** ile gelen isteklerde validasyon yapılmaktadır.
- **AutoMapper** ile Entity ve DTO nesneleri arasında kolay dönüşüm sağlanmıştır.

---

## 📢 Notlar

- Hassas bilgiler (connection string gibi) `.gitignore` dosyası aracılığıyla repodan hariç tutulmuştur.
- Veritabanı işlemleri **EF Core Migrations** kullanılarak yönetilmektedir.

---

## ✍️ Geliştirici

- GitHub: [YildirimogCod](https://github.com/YildirimogCod)

