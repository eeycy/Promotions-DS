using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using EEY.DigitalServices.Data;
using EEY.DigitalServices.API;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class QualificationsModel : PageModel
    {
        private readonly ILogger<QualificationsModel> _logger;
        private PromotionApplicationQualificationService _paqService { get; set; }

        public List<PromotionApplicationQualification> TeacherQualifications { get; set; } = new List<PromotionApplicationQualification>();
        public int ApplicationIndex;

        public QualificationsModel(ILogger<QualificationsModel> logger, PromotionApplicationQualificationService pacService)
        {
            _logger = logger;
            _paqService = pacService;
        }

        public async Task<IActionResult> OnGetAsync(string applid)
        {
            if (applid != null)
            {
                ApplicationIndex = JsonConvert.DeserializeObject<int>(applid);

                // CID - DEBUGGING:
                int dummyApplicationIndex = 1;

                TeacherQualifications = await _paqService.GetAppQualifications(dummyApplicationIndex);
            }

            else
                return NotFound();


            return Page();

        }

    }
}
