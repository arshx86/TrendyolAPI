# TrendyolAPI

Trendyol API'si ile hesaba ait ödemeler, sipariş geçmişi, ürün geçmişi vs gibi şeylere erişmek için ihtiyacınz olan tek DLL kütüphanesi.

## Özellikler

* Hızlı, Rest API'den güç alındı.
* Proxy Desteği

## Nasıl kullanılır?

* NET Framework 4.8 altında release ile build edebilirsiniz.
* [Hazır Halini burdan edinebilirsin.](https://github.com/arshx86/TrendyolAPI/releases)

DLL kütüphanesini .NET projene aktarıyosun.

Email ve şifre ile hesaba giriş yapıyorsun.

```csharp
using TrendyolAPI;
...
TrendyolClient client = new TrendyolClient(email, sifre);
```

Hesaba giriş yaptıktan sonra **client** objesi ile istediğin şeylere erişebilirsin.

Örnek çekebileceğin şeyler;

* **client.History** - `Ürün Geçmişi`
* **client.Addresses** - `Kayıtlı Adresler`
* **client.Purchases** - `Satın Alınan Ürünler ve Kargo Bilgileri`
* **client.Account** - `Hesaba Ait Bilgiler`
* **client.Cards** - `Kayıtlı Kart Bilgileri (kısıtlı erişim)`

### Örnek: Hesap Bilgilerini Çekme
```csharp
var hesapBilgisi = client.Account.UserInfo;
Console.WriteLine($"Isim Soyisim: {hesapBilgisi.FirstName} {hesapBilgisi.LastName}");
Console.WriteLine($"Telefon Numarası: {hesapBilgisi.Phone.Number}");
```

### Örnek: Adresleri Çekme
```csharp
foreach (AResult address in wc.Addresses.Result)
{
    Console.WriteLine($"{address.AddressName} / {address.AddressLine}");
}
```

### Bilinen Sorunlar
* 2 faktör desteklenmiyor.
* Kayıtlı kartlara erişim limitli olsa da, henüz imkansız durumda. (todo)
* Proje 2021'de yapıldı, bazı yerlerde sıkıntılar, hatalar mevcut olabilir. Issues kısmından bildirebilirsiniz.
* Proje, Trendyol Rest API'sini öğrenmek amacıyla yapıldı, bu library ile kötü anlamda yapabileceğin hiç bir şeyden ben sorumlu değilim.

### Lisans

İletişim: arshx86@protonmail.com
MIT adı altında lisanslanmıştır.
