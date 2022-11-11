using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class ApplicationHistoryModel : PageModel
    {
        private readonly ILogger<ApplicationHistoryModel> _logger;

        // 
        public List<Mock.Data.PromotionApplication> Applications { get; set; } = new List<Mock.Data.PromotionApplication> { };


        public ApplicationHistoryModel(ILogger<ApplicationHistoryModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //
            // Fill with MOCK Data!

            Applications = Mock.Services.EEYWebService.getPromotionApplications();
        }

    }
}
