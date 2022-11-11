using System;

namespace EEY.DigitalServices.Promotions.Mock.Data
{
    public class Teacher
    {
        // Πληροφορίες εκπαιδευτικού
        // Data populated by Web Service: Get_Promotion_Info_ByID
        // ΅Web Service Arguments: a string containing the ID of a teacher

        public Teacher()
        {
            IDNumber = 0;
            Level = 0;
            FileNumber = 0;
            LastName = "";
            FirstName = "";
            DateOfBirth = DateTime.Now;
            ServiceCode = 0;
            SpecialtyCode = 0;
            Specialty = "";
            SpecialtyFull = "";
            TelNumber = "";
            EMail = "";
        }

        public Teacher(
            int idNumber,
            byte level,
            int fileNumber,
            string lastName,
            string firstName,
            DateTime dateOfBirth,
            int serviceCode,
            int specialtyCode,
            string specialty,
            string specialtyFull,
            string telNumber,
            string eMail
        )
        {
            IDNumber = idNumber;
            Level = level;
            FileNumber = fileNumber;
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            ServiceCode = serviceCode;
            SpecialtyCode = specialtyCode;
            Specialty = specialty;
            SpecialtyFull = specialtyFull;
            TelNumber = telNumber;
            EMail = eMail;
        }

        //Personal_IdNo
        public int IDNumber { get; set; }

        //Personal_Vathmida
        public byte Level { get; set; }

        //Personal_Fakellos
        public int FileNumber { get; set; }

        //Personal_LastName
        public string LastName { get; set; } = string.Empty;

        //Personal_FirstName
        public string FirstName { get; set; } = string.Empty;

        //Personal_Dob
        public DateTime DateOfBirth { get; set; }

        //ServHist_ServCode
        public int ServiceCode { get; set; }

        //ServHist_SpecialtyCode
        public int SpecialtyCode { get; set; }

        //Eidikotita (fn_OnSpecificDateEidikotita)
        public string Specialty { get; set; } = string.Empty;

        //EidikothtaALL (fn_allSpecialties)
        public string SpecialtyFull { get; set; } = string.Empty;

        //Personal_MobileTel
        public string TelNumber { get; set; } = string.Empty;

        //Personal_EMail
        public string EMail { get; set; } = string.Empty;

    }
}
