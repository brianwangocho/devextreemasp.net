using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using RazorPages.Models;

namespace RazorPages.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        
            [HttpGet]
            public object Get(DataSourceLoadOptions loadOptions)
            {
            List<Models.User> userlist = null;
            string token = Request.Cookies["TOKEN"];
            string url = "https://powerful-refuge-65952.herokuapp.com/user-profile/v1/";

            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer "+token);

            //HTTP GET
            var responseTask = client.GetAsync("users");
            
            responseTask.Wait();

            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Models.User>>();
                readTask.Wait();
                userlist = readTask.Result;
                return DataSourceLoader.Load(userlist, loadOptions);
            }
            else
            {
                //Error response received   
                userlist = (List<User>)Enumerable.Empty<User>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }


            return DataSourceLoader.Load(userlist, loadOptions);
        }

        
    }
}
