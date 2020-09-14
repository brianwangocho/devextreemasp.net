using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Service;
using RazorPages.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace RazorPages.Pages.Auth
{
    public class LoginModel : PageModel
    {

        /// <summary>
        ///  inject the auth Interface
        /// </summary>
        private readonly IAuthInterface _authInterface;
        /// <summary>
        /// call the model you are using
        /// </summary>
        public LoginInput logininput;

        public LoginModel(IAuthInterface authInterface)
        {
            _authInterface = authInterface;
        }

    


        [BindProperty]
        public LoginInput LoginData { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            JObject c = await _authInterface.Asynclogin(LoginData);
            string phone = (string)c["phone"];
            string token = (string)c["token"];
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("TOKEN", token,cookieOptions);



            return RedirectToPage("/Index");
        }
    }
}
