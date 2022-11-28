using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EEY.DigitalServices.Data;
using EEY.DigitalServices.API;
using System;
using Microsoft.AspNetCore.Http;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class QualificationsAddEditModel : PageModel
    {
        private readonly ILogger<QualificationsAddEditModel> _logger;
        private PromotionApplicationQualificationService _paqService { get; set; }

        [BindProperty]
        public PromotionApplicationQualification Qualification { get; set; } = new PromotionApplicationQualification();


        public QualificationsAddEditModel(ILogger<QualificationsAddEditModel> logger, PromotionApplicationQualificationService pacService)
        {
            _logger = logger;
            _paqService = pacService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            int ApplicationIndex, QualificationKey;

            if (HttpContext.Session.TryGetValue("ApplicationIndex", out byte[] resultai))
            {
                ApplicationIndex = (int) HttpContext.Session.GetInt32("ApplicationIndex");

                if (HttpContext.Session.TryGetValue("QualificationKey", out byte[] resultqk))
                {
                    QualificationKey = (int) HttpContext.Session.GetInt32("QualificationKey");

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

                }
                else
                    return NotFound();

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
                        Qualification.FromYear = 1971;

                    // CID - DEBUGGING:
                    int originalApplicationIndex = Qualification.ApplicationCode;
                    Qualification.ApplicationCode = 1;
                    
                    Qualification = await _paqService.Save(Qualification);

                    // CID - DEBUGGING:
                    Qualification.ApplicationCode = originalApplicationIndex;

                    // CID - SHOULD RETURN TO THE REFERENCING PAGE.
                    // I.E. IF I AM COMING FROM PAGE CheckDetails, I SHOULD RETURN TO THAT
                    return RedirectToPage("/Qualifications");
                }

            }

            return NotFound();

        }

    }
}
