using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using EEY.DigitalServices.Data;
using EEY.DigitalServices.API;
using System.Collections.Generic;

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

        public async Task<IActionResult> OnGetAsync(string qualid, string applid)
        {
            if (qualid != null && applid != null)
            {
                int qualificationIndex = JsonConvert.DeserializeObject<int>(qualid);
                int applicationIndex = JsonConvert.DeserializeObject<int>(applid);

                if (qualificationIndex > 0)
                {
                    Qualification = await _paqService.Get(qualificationIndex);
                }
                else
                {
                    Qualification = new PromotionApplicationQualification();
                    Qualification.ApplicationCode = applicationIndex;
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

                    Dictionary<string, string> getArguments = new Dictionary<string, string>() { { "applid", JsonConvert.SerializeObject(Qualification.ApplicationCode) } };

                    // CID - SHOULD RETURN TO THE REFERENCING PAGE.
                    // I.E. IF I AM COMING FROM PAGE CheckDetails, I SHOULD RETURN TO THAT
                    return RedirectToPage("/Qualifications", getArguments);
                }

            }

            return NotFound();

        }

    }
}
