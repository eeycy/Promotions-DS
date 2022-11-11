using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using EEY.DigitalServices.Promotions.Mock.Data;

namespace EEY.DigitalServices.Promotions.Mock.Services
{
    public class EEYWebService
    {
        public EEYWebService()
        {
            // Initialize Web Service Object
        }


        public static List<PublishedPost> getAvailablePosts()
        {

            return getDataList<PublishedPost>("avpost.txt");

        }
        public static List<PromotionApplication> getPromotionApplications()
        {

            return getDataList<PromotionApplication>("appl.txt");

        }

        private static List<T> getDataList<T>(string dataFile)
        {

            string dataFilePath = Path.Combine("", dataFile);
            string[] userData;
            List<T> records = new List<T>();

            if (File.Exists(dataFilePath))
            {
                userData = File.ReadAllLines(dataFilePath);
                if (userData != null)
                {
                    foreach (string dataLine in userData)
                    {
                        if (dataLine != null)
                        {
                            T record = JsonConvert.DeserializeObject<T>(dataLine);
                            if (record != null)
                                records.Add(record);
                        }
                    }
                }
            }

            return records;

        }


        public static Teacher getPersonalInfo(string Id)
        {

            string dataFilePath = Path.Combine("", "user.txt");
            string[] userData;

            if (File.Exists(dataFilePath))
            {
                userData = File.ReadAllLines(dataFilePath);
                if (userData != null)
                {
                    foreach (string dataLine in userData)
                    {
                        if (dataLine != null)
                        {
                            Teacher record = JsonConvert.DeserializeObject<Teacher>(dataLine);
                            if (record != null)
                                return record;
                        }
                    }
                }
            }

            return new Teacher(int.Parse(Id), 2, 123456, "Γεωργίου", "Γεωργία", DateTime.Now, 1, 1, "Φιλόλογος", "Καθηγήτρια ΦΙλολογικών", "22554433", "georgiag@mail.com");

        }


        public static void updatePersonalInfo(Teacher recordToUpdate)
        {
            updateRecord(recordToUpdate, "user.txt");
        }


        public static PromotionApplication getApplication(int Id)
        {

            string dataFilePath = Path.Combine("", "appl.txt");
            string[] userData;
            List<PromotionApplication> records = new List<PromotionApplication>();

            if (File.Exists(dataFilePath))
            {
                userData = File.ReadAllLines(dataFilePath);
                if (userData != null)
                {
                    foreach (string dataLine in userData)
                    {
                        if (dataLine != null)
                        {
                            PromotionApplication record = JsonConvert.DeserializeObject<PromotionApplication>(dataLine);
                            if (record != null && record.IDNumber == Id)
                                return record;
                        }
                    }
                }
            }

            return new PromotionApplication(-1, new PublishedPost(), false);

        }

        public static void updateRecord<T>(T recordToUpdate, string dataFile)
        {
            // This is a MOCK, way!!
            // Read all data!
            List<T> records = getDataList<T>(dataFile);
            //Empty the file
            string dataFilePath = Path.Combine("", dataFile);
            File.WriteAllText(dataFilePath, string.Empty);
            bool addNewLine = false;

            // Write all back with the new record!
            if (records != null)
                foreach (T record in records)
                {
                    if (record != null)
                        if (record.GetType() == typeof(Teacher))
                        {
                            if ((record as Teacher).IDNumber == (recordToUpdate as Teacher).IDNumber)
                                saveRecord<Teacher>(recordToUpdate as Teacher, dataFile, addNewLine);
                            else
                                saveRecord<Teacher>(record as Teacher, dataFile, addNewLine);

                            addNewLine = true;
                        }

                }

        }


        private static int saveRecord<T>(T record, string dataFile, bool addNewLine)
        {

            string dataFilePath = Path.Combine("", dataFile);

            string recordText = JsonConvert.SerializeObject(record);

            File.AppendAllText(dataFilePath, addNewLine ? Environment.NewLine + recordText : recordText);

            return 0;

        }

    }
}
