namespace EEY.DigitalServices.Promotions.Mock.Data
{
    public class PromotionApplication
    {
        // Πληροφορίες για μια αίτηση για προαγωγή
        // Data populated by Web Service: Get_Promotion_Info_ByID
        // ΅Web Service Arguments: a string containing the ID of a teacher

        public PromotionApplication()
        {
            IDNumber = 0;
            PostDetails = new PublishedPost();
            Active = false;
        }

        public PromotionApplication(int idNumber, PublishedPost postDetails, bool active)
        {
            IDNumber = idNumber;
            PostDetails = postDetails;
            Active = active;
        }

        //apphSummary_Autokey(promApp_Autokey)
        public int IDNumber { get; set; }

        // Post details are the fields of PublishedPost repeated for history
        public PublishedPost PostDetails { get; set; }

        //apphSummary_Active (fn_ari_IsPublicationActive)
        public bool Active { get; set; }

    }
}
