#region

using System;
using System.Linq;
using Leaf.xNet;
using Newtonsoft.Json;
using TrendyolAPI.Models;

#endregion

namespace TrendyolAPI
{
    public class TrendyolClient
    {
        private static HttpRequest httpClient = new HttpRequest();

        private readonly string __email;
        private readonly string __password;

        /// <summary>
        ///     Hesap bilgileri.
        /// </summary>
        public Account Account;

        /// <summary>
        ///     Kayıtlı adres bilgileri.
        /// </summary>
        public Address Addresses;

        /// <summary>
        ///     Bakılan ürün geçmişi.
        /// </summary>
        public History History;

        /// <summary>
        ///     Satın alınan ürün bilgileri.
        /// </summary>
        public Purchases Purchases;

        /// <summary>
        ///     Client'i hazırlar.
        /// </summary>
        /// <param name="Email">Hesap maili</param>
        /// <param name="Password">Hesap şifresi</param>
        /// <param name="Proxy">Proxy</param>
        public TrendyolClient(string Email, string Password, string Proxy = null)
        {
            const string GirisUrl = "https://auth.trendyol.com/login";
            const string SiparislerUrl = "https://public-sdc.trendyol.com/discovery-web-omsgw-service/orders?page=1&sorting=0&storefrontId=1&searchText=";
            const string AdresListesiUrl = "https://public-sdc.trendyol.com/discovery-web-accountgw-service/api/address/list/mask?culture=tr-TR&storefrontId=1";
            const string GecmisUrl = "https://public-mdc.trendyol.com/discovery-web-websfxproductbrowsinghistory-santral/history?page=0";
            const string KullaniciBilgileriUrl = "https://public-sdc.trendyol.com/discovery-web-membergw-service/fragment/user-information/Hesabim/KullaniciBilgileri?culture=tr-TR&storefrontId=1";

            #region httpClient hazırlık

            httpClient = new HttpRequest
            {
                KeepAliveTimeout = 7000,
                ConnectTimeout = 7000,
                ReadWriteTimeout = 7000,
                IgnoreProtocolErrors = true,
                AllowAutoRedirect = true,
                UseCookies = true
            };
            if (Proxy != null) httpClient.Proxy = HttpProxyClient.Parse(Proxy);

            httpClient.UserAgentRandomize();
            httpClient.AddHeader("Platform", "Android");
            httpClient.AddHeader("Gender", "M");
            httpClient.AddHeader("OSVersion", "5.1.1");
            httpClient.AddHeader("Accept-Language", "tr-TR");
            httpClient.AddHeader("storefront-id", "1");
            httpClient.AddHeader("application-id", "1");
            httpClient.AddHeader("Content-Type", "application/json; charset=UTF-8");
            httpClient.AddHeader("Host", "auth.trendyol.com");
            httpClient.AddHeader("Accept-Encoding", "gzip, deflate");
            httpClient.AddHeader("Culture", "tr-TR");
            httpClient.AddHeader("origin", "https://auth.trendyol.com");

            #endregion

            #region Giriş / Token alma

            // Kullanıcı kimlik bilgilerini hazırlıyoruz
            var girisJson = JsonConvert.SerializeObject(new
            {
                email = Email,
                password = Password
            });

            HttpResponse girisYaniti = httpClient.Post(GirisUrl, girisJson, "application/json;charset=UTF-8");
            string girisResponse = girisYaniti.ToString();

            // Giriş hatalarını kontrol ediyoruz
            if (girisResponse.Contains("E-posta adresiniz ve/veya şifreniz hatalı.")) throw new Exception("E-posta adresiniz ve/veya şifreniz hatalı.");
            if (girisResponse.Contains("1015")) throw new Exception("Hız limitine ulaşıldı.");

            // Çerezlerden erişim belirtecini ( access token) çıkarıyoruz
            string token = girisYaniti.Cookies.GetCookies(GirisUrl)?["access_token"]?.Value;
            if (string.IsNullOrEmpty(token)) throw new Exception("Token alınamadı: " + girisResponse);

            httpClient.Authorization = "Bearer " + token;

            #endregion

            Purchases = JsonConvert.DeserializeObject<Purchases>(Get(SiparislerUrl));
            Addresses = JsonConvert.DeserializeObject<Address>(Get(AdresListesiUrl));
            History = JsonConvert.DeserializeObject<History>(Get(GecmisUrl));

            #region Kullanıcı bilgilerini çekme

            string deger = Get(KullaniciBilgileriUrl);
            dynamic sonuc = JsonConvert.DeserializeObject<object>(deger);
            sonuc = sonuc["result"]["hydrateScript"].ToString();
            sonuc = Btw(sonuc, "['__USER_INFORMATION_APP_INITIAL_STATE__'] = ", "; window.T");
            Account = JsonConvert.DeserializeObject<Account>(sonuc);

            #endregion

            #region Kartları Çekme

            // ŞU ANDA ÇALIŞMIYOR.

            // // Eskiden API ile gelen şey şimdi dökümana saklanmış durumda
            // // Parseliyoruz
            // string kayitli_kartlarim_raw = Get("https://www.trendyol.com/Hesabim/KrediKartlarim").ToString();
            //
            // // Kesme noktası olmadığı için direkt olarak jsonun içinden ayıklıyoruz
            // // Daha sonra ayıkladığımız yeri tekrar ekliyoruz ki deserializer sıkıntı çıkarmasın :D
            // string tamda_surasi = Btw(kayitli_kartlarim_raw, "cards", "https://collect.trendyol.com");
            // tamda_surasi = "\"{\\\"cards\\\":" + tamda_surasi + "\" }";
            // Cards = JsonConvert.DeserializeObject<List<Card>>(tamda_surasi);

            #endregion

            __email = Email;
            __password = Password;
        }

        /// <summary>
        ///     HTTP Get
        /// </summary>
        internal string Get(string link)
        {
            return httpClient.Get(link).ToString();
        }

        internal string Btw(string text, string left, string right)
        {
            int num = text.IndexOf(left, StringComparison.Ordinal);
            if (num == -1) return string.Empty;

            num += left.Length;
            int num2 = text.IndexOf(right, num, StringComparison.Ordinal);
            if (num2 == -1) return string.Empty;

            return text.Substring(num, num2 - num).Trim();
        }
    }
}