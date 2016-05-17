using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Webshop
{
    public class WebApiClient
    {
        public string AuthToken { get; set; }
        private static readonly string BaseAdress = System.Configuration.ConfigurationManager.AppSettings["WebApiBaseAddress"];

        private HttpClient GetClient()
        {
            var client = new HttpClient {BaseAddress = new Uri(BaseAdress)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Send the token when authenticated to the webapi
            if (!string.IsNullOrEmpty(AuthToken))
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + AuthToken);
            else if (!string.IsNullOrEmpty(HttpContext.Current.Response.Cookies.Get("AuthToken").Value))
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + HttpContext.Current.Response.Cookies.Get("AuthToken").Value);

            return client;
        }

        private static WebApiClient _obj;

        public static WebApiClient Obj
        {
            get { return _obj ?? (_obj = new WebApiClient()); }
        }

        public List<T> GetAll<T>(string uri)
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

        public T Get<T>(string uri)
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

        public async Task<TResult> Post<T, TResult>(string uri, T content)
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
            var encodedForm = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("userName", userName),
                new KeyValuePair<string, string>("password", password)
            });

            try
            {
                using (var client = GetClient())
                {
                    var response = await client.PostAsync("token", encodedForm);
                    //response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();

                    var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                    if (values.ContainsKey("access_token"))
                    {
                        this.AuthToken = values["access_token"];
                        return true;
                    }

                    if (values.ContainsKey("error") && values["error"].Equals("invalid_grant"))
                        return false;
                    
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}