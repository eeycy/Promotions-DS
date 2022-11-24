using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EEY.DigitalServices.Data;
using EEY.DigitalServices.API;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class QualificationsModel : PageModel
    {
        private readonly ILogger<QualificationsModel> _logger;
        private PromotionApplicationQualificationService _paqService { get; set; }

        [TempData]
        public int ApplicationIndexTemp { get; set; }
        [TempData]
        public int QualificationKeyTemp { get; set; }

        [BindProperty]
        public int ApplicationIndex { get; set; }
        [BindProperty]
        public int QualificationKey { get; set; }

        public List<PromotionApplicationQualification> TeacherQualifications { get; set; } = new List<PromotionApplicationQualification>();

        public QualificationsModel(ILogger<QualificationsModel> logger, PromotionApplicationQualificationService pacService)
        {
            _logger = logger;
            _paqService = pacService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ApplicationIndex = ApplicationIndexTemp;
            if (ApplicationIndex > 0)
            {
                // CID - DEBUGGING:
                int dummyApplicationIndex = 1;

                TeacherQualifications = await _paqService.GetAppQualifications(dummyApplicationIndex);
            }

            else
                return NotFound();


            return Page();

        }
        public IActionResult OnPostAddEditQualification()
        {
            ApplicationIndexTemp = ApplicationIndex;
            QualificationKeyTemp = QualificationKey;
            return RedirectToPage("/QualificationsAddEdit");
        }

        public IActionResult OnPostNextPage()
        {
            ApplicationIndexTemp = ApplicationIndex;
            return RedirectToPage("/CheckDetails");
        }
    }
}
