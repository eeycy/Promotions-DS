using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class EditEmailDetailsModel : PageModel
    {
        private readonly ILogger<EditEmailDetailsModel> _logger;


        [BindProperty, Required]
        public string EMail { get; set; }

        [BindProperty]
        public Mock.Data.Teacher ApplicantTeacher { get; set; }


        public EditEmailDetailsModel(ILogger<EditEmailDetailsModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            int ApplicationIndex;

            if (HttpContext.Session.TryGetValue("ApplicationIndex", out byte[] resultai))
            {
                ApplicationIndex = (int) HttpContext.Session.GetInt32("ApplicationIndex");

                if (ApplicationIndex > 0)
                {
                    // Get the data from EEY Web Service
                    ApplicantTeacher = Mock.Services.EEYWebService.getPersonalInfo("876123");

                    // Polulate bind property
                    EMail = ApplicantTeacher.EMail;

                    return Page();
                }

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
                ApplicantTeacher.EMail = EMail;
                
                // Update record using EEY Web Service
                Mock.Services.EEYWebService.updatePersonalInfo(ApplicantTeacher);

                // CID - SHOULD RETURN TO THE REFERENCING PAGE.
                // I.E. IF I AM COMING FROM PAGE CheckDetails, I SHOULD RETURN TO THAT

                return RedirectToPage("/CheckDetails");

            }

        }

    }

}
