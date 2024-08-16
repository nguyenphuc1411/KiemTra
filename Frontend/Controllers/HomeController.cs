using Frontend.Models;
using KiemTra.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index(int month = 8, int year =2024, int page =1)
        {
            var apiUrl = $"https://localhost:7009/api/ratings?month={8}&year={2024}&page={1}";

            try
            {
                // Call API
                var response = await _httpClient.GetFromJsonAsync<List<Rating>>(apiUrl);

                // Check if response is successful and not null
                if (response != null)
                {
                    return View(response);
                }
                else
                {
                    ViewBag.ApiData = "No data available for the specified month and year.";
                }
            }
            catch (Exception ex)
            {
                // Handle other possible errors
                ViewBag.ApiData = $"An unexpected error occurred: {ex.Message}";
            }

            return View();
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
