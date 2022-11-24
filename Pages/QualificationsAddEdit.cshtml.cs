using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EEY.DigitalServices.Data;
using EEY.DigitalServices.API;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class QualificationsAddEditModel : PageModel
    {
        private readonly ILogger<QualificationsAddEditModel> _logger;
        private PromotionApplicationQualificationService _paqService { get; set; }

        [TempData]
        public int ApplicationIndexTemp { get; set; }
        [TempData]
        public int QualificationKeyTemp { get; set; }


        [BindProperty]
        public int ApplicationIndex { get; set; }
        [BindProperty]
        public int QualificationKey { get; set; }

        [BindProperty]
        public PromotionApplicationQualification Qualification { get; set; } = new PromotionApplicationQualification();


        public QualificationsAddEditModel(ILogger<QualificationsAddEditModel> logger, PromotionApplicationQualificationService pacService)
        {
            _logger = logger;
            _paqService = pacService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ApplicationIndex = ApplicationIndexTemp;
            QualificationKey = QualificationKeyTemp;

            if (ApplicationIndex > 0 && QualificationKey >= 0)
            {
                if (QualificationKey > 0)
                {
                    Qualification = await _paqService.Get(QualificationKey);

                    // CID - DEBUGGING:
                    // The service does not return a valid code (always 1).
                    // Replace it with the one from page
                    Qualification.ApplicationCode = ApplicationIndex;
                }
                else
                {
                    Qualification = new PromotionApplicationQualification();
                    Qualification.ApplicationCode = ApplicationIndex;
                }
            }
            else
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || Qualification == null)
            {
                return Page();
            }
            else
            {
                if (Qualification != null)
                {
                    // CID - DEBUGGING - SHOULD BE ADDRESSED
                    if (Qualification.FromYear == 0)
                        Qualification.FromYear = 2000;

                    // CID - DEBUGGING:
                    int originalApplicationIndex = Qualification.ApplicationCode;
                    Qualification.ApplicationCode = 1;
                    
                    Qualification = await _paqService.Save(Qualification);

                    // CID - DEBUGGING:
                    Qualification.ApplicationCode = originalApplicationIndex;

                    // CID - SHOULD RETURN TO THE REFERENCING PAGE.
                    // I.E. IF I AM COMING FROM PAGE CheckDetails, I SHOULD RETURN TO THAT
                    ApplicationIndexTemp = Qualification.ApplicationCode;
                    return RedirectToPage("/Qualifications");
                }

            }

            return NotFound();

        }

    }
}
