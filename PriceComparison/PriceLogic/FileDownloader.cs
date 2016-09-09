//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;

//namespace PriceLogic
//{
//    public class FileDownloader
//    {
//       public FileDownloader(string storeLastUpdate, string itemLastUpdate)
//        {
//            StoreLastUpdate = storeLastUpdate;
//            ItemLastUpdate = itemLastUpdate;
//            FullItemOn = false;
//            FullStoreOn = false;
//        }
//        public string StoreLastUpdate { get; set; }
//        public string ItemLastUpdate { get; set; }
//        public bool FullItemOn { get; set; }
//        public bool FullStoreOn { get; set; }
//        public string UrlPath { get; } = "https://url.publishedprices.co.il/login";
//        public List<string> Logins { get; } = new List<string>() { "doralon", "hazihinam", "yohananof" };
//        public object JObject { get; private set; }

//        public void StartDownload()
//        {
//            string currDate = DateTime.Now.ToString("yyyyMMdd");
//            if (StoreLastUpdate.CompareTo(currDate) < 0)
//            {
//                FullStoreOn = true;
//            }
//            if (ItemLastUpdate.CompareTo(currDate) < 0)
//            {
//                FullItemOn = true;
//            }
//            foreach (string chain in Logins)
//            {
//                Login(chain);
//            }
//        }
//        public async void Login(string chain)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri(UrlPath);
//                client.DefaultRequestHeaders.Accept.Clear();
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                //setup login data
//                var username = chain;

//                var formContent = new FormUrlEncodedContent(new[]
//                {
// new KeyValuePair<string, string>("username", username),
// });
//                //send request
//                HttpResponseMessage responseMessage = await client.PostAsync("/Token", formContent);

//                //get access token from response body
//                var responseJson = await responseMessage.Content.ReadAsStringAsync();
//                var jObject = JObject.Parse(responseJson);
//                var token = jObject.GetValue("access_token").ToString();



//            }
//        }
//    }
