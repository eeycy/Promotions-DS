using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EEY.DigitalServices.Promotions.Pages
{
    public class EditEmailDetailsModel : PageModel
    {
        private readonly ILogger<EditEmailDetailsModel> _logger;

        [BindProperty]
        public int ApplicationIndex { get; set; }

        [BindProperty]
        public Mock.Data.Teacher ApplicantTeacher { get; set; } = new Mock.Data.Teacher();


        public EditEmailDetailsModel(ILogger<EditEmailDetailsModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet(string applid)
        {
            if (applid != null)
            {
                ApplicationIndex = JsonConvert.DeserializeObject<int>(applid);

                ApplicantTeacher = Mock.Services.EEYWebService.getPersonalInfo("876123");

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
                Mock.Services.EEYWebService.updatePersonalInfo(ApplicantTeacher);

                // CID - SHOULD RETURN TO THE REFERENCING PAGE.
                // I.E. IF I AM COMING FROM PAGE CheckDetails, I SHOULD RETURN TO THAT

                Dictionary<string, string> getArguments = new Dictionary<string, string>() { { "applid", JsonConvert.SerializeObject(ApplicationIndex) } };

                return RedirectToPage("/CheckDetails", getArguments);

            }

        }

    }

}
