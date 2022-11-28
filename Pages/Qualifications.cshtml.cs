using System.Collections.Generic;
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
    public class QualificationsModel : PageModel
    {
        private readonly ILogger<QualificationsModel> _logger;
        private PromotionApplicationQualificationService _paqService { get; set; }

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
            int ApplicationIndex;

            if (HttpContext.Session.TryGetValue("ApplicationIndex", out byte[] result))
            {
                ApplicationIndex = (int) HttpContext.Session.GetInt32("ApplicationIndex");

                if (ApplicationIndex > 0)
                {
                    // CID - DEBUGGING:
                    int dummyApplicationIndex = 1;

                    TeacherQualifications = await _paqService.GetAppQualifications(dummyApplicationIndex);
                }
                else
                    return NotFound();
            }
            else
                return NotFound();


            return Page();

        }

        public IActionResult OnPostAddEditQualification()
        {
            HttpContext.Session.SetInt32("QualificationKey", QualificationKey);
            return RedirectToPage("/QualificationsAddEdit");
        }

        public IActionResult OnPostNextPage()
        {
            return RedirectToPage("/CheckDetails");
        }
    }
}
