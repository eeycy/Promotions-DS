using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class PositionSelectionModel : PageModel
    {
        private readonly ILogger<PositionSelectionModel> _logger;

        //
        public List<Mock.Data.PublishedPost> AvailablePosts { get; set; } = new List<Mock.Data.PublishedPost> { };

        // 
        public List<Mock.Data.PromotionApplication> Applications { get; set; } = new List<Mock.Data.PromotionApplication> { };

        public PositionSelectionModel(ILogger<PositionSelectionModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //
            // CID - Fill with MOCK Data!

            AvailablePosts = Mock.Services.EEYWebService.getAvailablePosts();

            Applications = Mock.Services.EEYWebService.getPromotionApplications();

        }

    }
}
