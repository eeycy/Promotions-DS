using System;

namespace EEY.DigitalServices.Promotions.Mock.Data
{
    public class PublishedPost
    {
        // Πληροφορίες για μια δημοσιευμένη θέση για προαγωγή
        // Data populated by Web Service: Get_Promotion_Info_ByID
        // ΅Web Service Arguments: a string containing the ID of a teacher

        public PublishedPost()
        {
            IDNumber = 0;
            PublicationID = 0;
            OpensOn = DateTime.Now;
            PostID = 0;
            Description = "";
            ServiceCode = 0;
            CanSubmitMilitaryCert = true;
            MilitaryCertComments = "";
        }

        public PublishedPost(
            int idNumber,
            int publicationID,
            DateTime opensOn,
            int postID,
            string description,
            int serviceCode,
            bool canSubmitMilitaryCert,
            string militaryCertComments
        )
        {
            IDNumber = idNumber;
            PublicationID = publicationID;
            OpensOn = opensOn;
            PostID = postID;
            Description = description;
            ServiceCode = serviceCode;
            CanSubmitMilitaryCert = canSubmitMilitaryCert;
            MilitaryCertComments = militaryCertComments;
        }


        //pubPost_Autokey
        public int IDNumber { get; set; }

        //pub_autokey / apphSummary_PubPostCode(promApp_PubPostCode)
        public int PublicationID { get; set; }

        //pub_opensOn / apphSummary_openDate(pub_opensOn)
        public DateTime OpensOn { get; set; }

        //post_code / apphSummary_PostCode(post_code)
        public int PostID { get; set; }

        //post_description / apphSummary_Description(post_description)
        public string Description { get; set; } = string.Empty;

        //post_serviceCode
        public int ServiceCode { get; set; }

        //post_EFEnabled (fn_PromotionApplications_EF_enabled) / apphSummary_EFEnabled
        public bool CanSubmitMilitaryCert { get; set; }

        //post_EFComments (fn_PromotionApplications_EF_comments) / apphSummary_EFComments
        public string MilitaryCertComments { get; set; } = string.Empty;

    }
}
