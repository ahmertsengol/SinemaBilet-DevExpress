# ?? SinemaBilet.DevExpress

Sinema bilet satýþ yönetim sistemi - Cinema ticket management system

## ?? Proje Özellikleri

- **Windows Forms** arayüzü
- **DevExpress** UI bileþenleri
- **.NET 8** ile geliþtirildi
- **Entity Framework** veritabaný yönetimi
- Kullanýcý yönetimi (Giriþ, Kaydol, Þifre Sýfýrlama)
- Bilet satýþ sistemi
- Personel yönetimi
- Raporlama özellikleri

## ??? Teknolojiler

- C# (.NET 8)
- Windows Forms
- DevExpress Controls
- Entity Framework Core
- SQLite / SQL Server

## ?? Kurulum

```bash
git clone https://github.com/kullaniciadin/SinemaBilet.DevExpress.git
cd SinemaBilet.DevExpress
dotnet restore
dotnet build
```

## ?? Çalýþtýrma

```bash
dotnet run
```

## ?? Proje Yapýsý

```
??? Domain/              # Veri modelleri (Salon, Bilet, Kullanici)
??? Data/                # Entity Framework AppDbContext
??? Helpers/             # DevExpress UI yardýmcý sýnýflar
??? Forms/               # Windows Forms sayfalarý
??? Program.cs           # Ana giriþ noktasý
```

## ?? Yazar

Mert

## ?? Lisans

MIT License
