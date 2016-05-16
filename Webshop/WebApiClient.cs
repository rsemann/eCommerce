using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Formatting;
using System.Windows.Media;

namespace Webshop
{
    public class WebApiClient<T>
    {
        public string AuthToken { get; set; }
        private static string _baseAdress = System.Configuration.ConfigurationManager.AppSettings["WebApiBaseAddress"];

        private static HttpClient GetClient()
        {
            var client = new HttpClient {BaseAddress = new Uri(_baseAdress)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public List<T> GetAll(string uri)
        {
            try
            {
                using (var client = GetClient())
                {
                    var response = client.GetAsync(uri).Result;
                    response.EnsureSuccessStatusCode();
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    return JsonConvert.DeserializeObject<List<T>>(jsonString.Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public T Get(string uri)
        {
            try
            {
                using (var client = GetClient())
                {
                    var response = client.GetAsync(uri).Result;
                    response.EnsureSuccessStatusCode();
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    return JsonConvert.DeserializeObject<T>(jsonString.Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(string uri)
        {
            try
            {
                using (var client = GetClient())
                {
                    var response = await client.DeleteAsync(uri);
                    response.EnsureSuccessStatusCode();

                    await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TResult> Delete<TResult>(string uri)
        {
            try
            {
                using (var client = GetClient())
                {
                    var response = await client.DeleteAsync(uri);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsAsync<TResult>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TResult> Post<TResult>(string uri, T content)
        {
            try
            {
                using (var client = GetClient())
                {
                    var response = await client.PostAsJsonAsync(uri, content);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsAsync<TResult>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Authenticate(string userName, string password)
        {
            return true;
        }
    }
}