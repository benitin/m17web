using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace m17web.Models
{
    public class ApiRestModel
    {

        public static string APIREST_URI = "http://localhost:3001/api/";

        public static T RestApiGet<T>(string uri)
        {
            T t = default(T);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIREST_URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    t = response.Content.ReadAsAsync<T>().Result;
                }
            }
            return t;
        }


        public static R RestApiPost<T, R>(string uri, T t)
        {
            R r = default(R);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIREST_URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = client.PostAsJsonAsync(uri, t).Result;
                if (response.IsSuccessStatusCode)
                {
                    r = response.Content.ReadAsAsync<R>().Result;
                }
            }
            return r;
        }
    }
}