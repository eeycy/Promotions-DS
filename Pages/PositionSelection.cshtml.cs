using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class PositionSelectionModel : PageModel
    {
        private readonly ILogger<PositionSelectionModel> _logger;

        [BindProperty]
        public int ApplicationIndex { get; set; }

        //
        public List<Mock.Data.PublishedPost> AvailablePosts { get; set; } = new List<Mock.Data.PublishedPost> { };

        // 
        public List<Mock.Data.PromotionApplication> Applications { get; set; } = new List<Mock.Data.PromotionApplication> { };

        public PositionSelectionModel(ILogger<PositionSelectionModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            //
            // CID - Fill with MOCK Data!

            AvailablePosts = Mock.Services.EEYWebService.getAvailablePosts();

            Applications = Mock.Services.EEYWebService.getPromotionApplications();

            HttpContext.Session.SetInt32("ApplicationIndex", ApplicationIndex);

            return Page();
        }

        public IActionResult OnPostEditApplication()
        {
            HttpContext.Session.SetInt32("ApplicationIndex", ApplicationIndex);
            return RedirectToPage("/CheckDetails");
        }

        public IActionResult OnPostNewApplication()
        {
            HttpContext.Session.SetInt32("ApplicationIndex", ApplicationIndex);
            return RedirectToPage("/Qualifications");
        }

    }
}
