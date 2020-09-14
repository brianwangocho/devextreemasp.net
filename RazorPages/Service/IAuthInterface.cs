using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RazorPages.Models;

namespace RazorPages.Service
{
   public interface IAuthInterface
    {
    
        Task<JObject> Asynclogin(LoginInput loginInput);
    }
}
