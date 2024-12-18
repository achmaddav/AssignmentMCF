using FrontendApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontendApp.Controllers
{
    public class BpkbController : Controller
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<IActionResult> FormInsert()
        {
            try
            {
                var locations = await _client.GetFromJsonAsync<List<MsStorageLocation>>("http://localhost:5071/api/MsStorageLocations/GetStorageLocations");
                ViewBag.Locations = locations ?? new List<MsStorageLocation>();

                var model = new TrBpkbModel();
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching locations: {ex.Message}");

                ViewBag.Locations = new List<MsStorageLocation>();
                return View(new TrBpkbModel());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Insert(TrBpkbModel model)
        {          
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("User not logged in.");
            }

            model.Username = username; 

            var response = await _client.PostAsJsonAsync("http://localhost:5071/api/TrBpkb/Insert", model);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Failed to save data.";
                return View("FormInsert", model);
            }

            return RedirectToAction("FormInsert");
        }

    }

}
