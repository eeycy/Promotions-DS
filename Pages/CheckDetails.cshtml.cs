using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EEY.DigitalServices.API;
using EEY.DigitalServices.Data;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class CheckDetailsModel : PageModel
    {
        private readonly ILogger<CheckDetailsModel> _logger;
        private PromotionApplicationQualificationService _paqService { get; set; }

        [TempData]
        public int ApplicationIndexTemp { get; set; }
        [TempData]
        public int QualificationKeyTemp { get; set; }

        [BindProperty]
        public int ApplicationIndex { get; set; }
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
            ApplicationIndex = ApplicationIndexTemp;
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


            return Page();

        }

        public IActionResult OnPostAddEditQualification()
        {
            ApplicationIndexTemp = ApplicationIndex;
            QualificationKeyTemp = QualificationKey;
            return RedirectToPage("/QualificationsAddEdit");
        }

        public IActionResult OnPostEditPhone()
        {
            ApplicationIndexTemp = ApplicationIndex;
            return RedirectToPage("/EditPhoneDetails");
        }

        public IActionResult OnPostEditEmail()
        {
            ApplicationIndexTemp = ApplicationIndex;
            return RedirectToPage("/EditEmailDetails");
        }

    }

}
