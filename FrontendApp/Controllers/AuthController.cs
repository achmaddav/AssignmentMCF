using FrontendApp.DTOs;
using FrontendApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontendApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _client = new HttpClient();

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var response = await _client.PostAsJsonAsync("http://localhost:5071/api/MsUser/Login", model);
            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserDto>();
                HttpContext.Session.SetString("Username", user.UserName); 
                return RedirectToAction("FormInsert", "Bpkb");
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }
    }

}
