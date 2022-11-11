using System.Collections.Generic;

namespace EEY.DigitalServices.Promotions.Mock.Data
{
    public class PromotionInfo
    {
        // Πληροφορίες για μια αίτηση για προαγωγή
        // Data populated by Web Service: Get_Promotion_Info_ByID
        // ΅Web Service Arguments: a string containing the ID of a teacher

        public PromotionInfo()
        {
            ApplicantTeacher = new Teacher();
            AvailablePosts = new List<PublishedPost>();
            Applications = new List<PromotionApplication>();
        }

        //
        public Teacher ApplicantTeacher { get; set; }

        // 
        public List<PublishedPost> AvailablePosts { get; set; }

        // 
        public List<PromotionApplication> Applications { get; set; }

    }
}
