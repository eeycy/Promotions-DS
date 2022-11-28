using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EEY.DigitalServices.API;
using EEY.DigitalServices.Data;
using System;
using Microsoft.AspNetCore.Http;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class CheckDetailsModel : PageModel
    {
        private readonly ILogger<CheckDetailsModel> _logger;
        private PromotionApplicationQualificationService _paqService { get; set; }

        [BindProperty]
        public int QualificationKey { get; set; }

        public Mock.Data.PromotionApplication CurrentApplication { get; set; } = new Mock.Data.PromotionApplication(0, new Mock.Data.PublishedPost(), false);
        public List<PromotionApplicationQualification> TeacherQualifications { get; set; } = new List<PromotionApplicationQualification>();
        public Mock.Data.Teacher ApplicantTeacher { get; set; } = new Mock.Data.Teacher();

        public CheckDetailsModel(ILogger<CheckDetailsModel> logger, PromotionApplicationQualificationService pacService)
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
                    ApplicantTeacher = Mock.Services.EEYWebService.getPersonalInfo("876123");

                    CurrentApplication = Mock.Services.EEYWebService.getApplication(ApplicationIndex);

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

    }

}
