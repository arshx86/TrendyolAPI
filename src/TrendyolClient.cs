using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leaf.xNet;
using Newtonsoft.Json;
using TrendyolAPI.Models;

namespace TrendyolAPI
{
    public class TrendyolClient
    {

        private readonly string __email;
        private readonly string __password;

        /// <summary>
        ///  Hesap bilgileri.
        /// </summary>
        public Account Account;

        /// <summary>
        ///  Kayıtlı adres bilgileri.
        /// </summary>
        public Address Addresses;

        /// <summary>
        ///  Hesaba ait kayıtlı kartlar.
        /// </summary>
        [Obsolete("Kütüphanenin bu versiyonu ile kullanılamaz.")]
        public List<Card> Cards;

        /// <summary>
        ///  Bakılan ürün geçmişi.
        /// </summary>
        public History History;

        /// <summary>
        ///  Satın alınan ürün bilgileri.
        /// </summary>
        public Purchases Purchases;

        /// <summary>
        ///  Cüzdan bakiyesi. NOT: Cüzdan bakiyesi limitlendirildi.
        /// </summary>
        [Obsolete("Trendyol Cüzdan artık kullanılmıyor.", false)]
        public string WalletBalance;

        /// <summary>
        ///  Client'i hazırlar.
        /// </summary>
        /// <param name="Email">Hesap maili</param>
        /// <param name="Password">Hesap şifresi</param>
        /// <param name="Proxy">Proxy (IP:PORT)</param>

        public TrendyolClient(string Email, string Password, string Proxy = null)
        {

            HttpRequest httpRequest = new HttpRequest
            {
                KeepAliveTimeout = 7000,
                ConnectTimeout = 7000,
                ReadWriteTimeout = 7000,
                IgnoreProtocolErrors = true,
                AllowAutoRedirect = true,
                UseCookies = true
            };
            if (Proxy != null)
            {
                httpRequest.Proxy = HttpProxyClient.Parse(Proxy);
            }

            #region Init Headers

            httpRequest.AddHeader("User-Agent", "Dalvik/2.1.0 (Linux; U; Android 5.1.1; SM-G977N Build/LMY48Z) Trendyol/5.16.3.559");
            httpRequest.AddHeader("Platform", "Android");
            httpRequest.AddHeader("Gender", "M");
            httpRequest.AddHeader("OSVersion", "5.1.1");
            httpRequest.AddHeader("Accept-Language", "tr-TR");
            httpRequest.AddHeader("storefront-id", "1");
            httpRequest.AddHeader("application-id", "1");
            httpRequest.AddHeader("Content-Type", "application/json; charset=UTF-8");
            httpRequest.AddHeader("Host", "auth.trendyol.com");
            httpRequest.AddHeader("Accept-Encoding", "gzip, deflate");
            httpRequest.AddHeader("Culture", "tr-TR");
            httpRequest.AddHeader("origin", "https://auth.trendyol.com");

            #endregion

            // POST - Request body
            string str = JsonConvert.SerializeObject(new
            {
                email = Email,
                password = Password
            });

            HttpResponse httpResponse = httpRequest.Post("https://auth.trendyol.com/login", str, "application/json;charset=UTF-8");
            string text = httpResponse.ToString();

            // Yanlış giriş.
            if (text.Contains("E-posta adresiniz ve/veya şifreniz hatalı."))
            {
                throw new Exception("E-posta adresiniz ve/veya şifreniz hatalı.");
            }

            // Rate limit.
            if (text.Contains("1015"))
            {
                throw new Exception("Rate limited.");
            }

            // Response ile dönen access_token'i alıyoruz.
            string text2 = httpResponse.Cookies.GetCookies("https://auth.trendyol.com")?["access_token"]?.Value;
            if (string.IsNullOrEmpty(text2))
            {
                throw new Exception("Token alınamadı: " + text);
            }

            #region Init REQS2

            httpRequest = new HttpRequest();
            httpRequest.Authorization = "Bearer " + text2;
            httpRequest.AddHeader("accept-encoding", "gzip, deflate, br");
            httpRequest.AddHeader("accept-language", "tr-TR,tr;q=0.9");
            httpRequest.AddHeader("accept", "*/*");
            httpRequest.AddHeader("ty-web-client-async-mode", "true");
            httpRequest.AddHeader("origin", "https://www.trendyol.com");
            httpRequest.AddHeader("if-none-match", "W/\"bef-XlNGfk71z0szC1jPfXRo+T89wsY\"");
            httpRequest.AddHeader("sec-fetch-desc", "empty");
            httpRequest.AddHeader("sec-fetch-mode", "cors");
            httpRequest.AddHeader("sec-fetch-site", "same-site");
            httpRequest.AddHeader("sec-gpc", "1");
            httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.102 Safari/537.36");
            // Cards = JsonConvert.DeserializeObject<List<Card>>(httpRequest.Get("https://public-sdc.trendyol.com/discovery-web-accountgw-service/api/saved-credit-cards").ToString());

            #endregion

            string text3 = httpRequest.Get("https://public-sdc.trendyol.com/discovery-web-walletgw-service/fragment/hesabim/cuzdanim?culture=tr-TR&storefrontId=1").ToString();
            WalletBalance = Btw(text3, "{\\\"balance\\\":{\\\"amount\\\":", ",\\\"rebateAmount\\\"");
            Purchases = JsonConvert.DeserializeObject<Purchases>(httpRequest.Get("https://public-sdc.trendyol.com/discovery-web-omsgw-service/orders?page=1&sorting=0&storefrontId=1&searchText=").ToString());
            Addresses = JsonConvert.DeserializeObject<Address>(httpRequest.Get("https://public-sdc.trendyol.com/discovery-web-accountgw-service/api/address/list/mask?culture=tr-TR&storefrontId=1").ToString());
            History = JsonConvert.DeserializeObject<History>(httpRequest.Get("https://public-mdc.trendyol.com/discovery-web-websfxproductbrowsinghistory-santral/history?page=0").ToString());

            // Hesap bilgileri json şeklinde çöp bir string'in arasına sıkıştırılmış.
            // Aradaki text'i alarak json deserialize...
            string value = httpRequest.Get("https://public-sdc.trendyol.com/discovery-web-membergw-service/fragment/user-information/Hesabim/KullaniciBilgileri?culture=tr-TR&storefrontId=1").ToString();
            dynamic val = JsonConvert.DeserializeObject<object>(value);
            val = val["result"]["hydrateScript"].ToString();
            val = Btw(val, "['__USER_INFORMATION_APP_INITIAL_STATE__'] = ", "; window.T");
            Account = JsonConvert.DeserializeObject<Account>(val);


            __email = Email;
            __password = Password;

        }

        internal string Btw(string text, string left, string right)
        {
            int num = text.IndexOf(left, StringComparison.Ordinal);
            if (num == -1)
            {
                return string.Empty;
            }

            num += left.Length;
            int num2 = text.IndexOf(right, num, StringComparison.Ordinal);
            if (num2 == -1)
            {
                return string.Empty;
            }

            return text.Substring(num, num2 - num).Trim();
        }
    }
}