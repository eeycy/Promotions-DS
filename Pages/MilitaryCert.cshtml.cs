using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class MilitaryCertModel : PageModel
    {
        private readonly ILogger<MilitaryCertModel> _logger;

        public MilitaryCertModel(ILogger<MilitaryCertModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
