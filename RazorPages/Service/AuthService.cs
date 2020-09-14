using Newtonsoft.Json.Linq;
using RazorPages.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RazorPages.Service
{
    public class AuthService :IAuthInterface
    {
        static HttpClient client = new HttpClient();

        //static async Task<HttpStatusCode> LoginUser(Models.LoginInput loginInput)
        //{
        //    HttpResponseMessage response = await client.PostAsJsonAsync(
        // "https://powerful-refuge-65952.herokuapp.com/authenticate", loginInput);
        //    response.EnsureSuccessStatusCode();
        //    return response.StatusCode;
        //}

        public async Task<JObject> Asynclogin(LoginInput loginInput)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
        "https://powerful-refuge-65952.herokuapp.com/authenticate", loginInput);
            string data = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(data);
            JObject json = JObject.Parse(data);
            string token = (string)json["token"];
            string phone = (string)json["phone"];

            Console.WriteLine(json);
            response.EnsureSuccessStatusCode();
            return json;



            throw new NotImplementedException();
         
        }
    }
}
