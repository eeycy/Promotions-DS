using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class EditPhoneDetailsModel : PageModel
    {
        private readonly ILogger<EditPhoneDetailsModel> _logger;

        [TempData]
        public int ApplicationIndexTemp { get; set; }


        [BindProperty]
        public int ApplicationIndex { get; set; }

        [BindProperty, Required]
        public string TelNumber { get; set; }

        [BindProperty]
        public Mock.Data.Teacher ApplicantTeacher { get; set; }


        public EditPhoneDetailsModel(ILogger<EditPhoneDetailsModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            ApplicationIndex = ApplicationIndexTemp;
            if (ApplicationIndex > 0)
            {
                // Get the data from EEY Web Service
                ApplicantTeacher = Mock.Services.EEYWebService.getPersonalInfo("876123");

                // Polulate bind property
                TelNumber = ApplicantTeacher.TelNumber;

                return Page();
            }

            return NotFound();

        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {

                // Update record with value from page
                ApplicantTeacher.TelNumber = TelNumber;

                // Update record using EEY Web Service
                Mock.Services.EEYWebService.updatePersonalInfo(ApplicantTeacher);

                // CID - SHOULD RETURN TO THE REFERENCING PAGE.
                // I.E. IF I AM COMING FROM PAGE CheckDetails, I SHOULD RETURN TO THAT

                ApplicationIndexTemp = ApplicationIndex;
                return RedirectToPage("/CheckDetails");

            }

        }

    }

}
