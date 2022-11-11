using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class ApplicationDataModel : PageModel
    {
        private readonly ILogger<ApplicationDataModel> _logger;


        public ApplicationDataModel(ILogger<ApplicationDataModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
