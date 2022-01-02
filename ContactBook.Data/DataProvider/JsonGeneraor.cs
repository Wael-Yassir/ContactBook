using System.IO;
using System.Text;
using Newtonsoft.Json;
using ContactBook.Data.Models;
using System.Collections.Generic;

namespace ContactBook.Data.DataProvider
{
    internal static class JsonGeneraor
    {
        private static string _dbPath = @"D:\Work\Development\_Side Project\ContactBook\DB";
        private static string _dbFileName = @"D:\Work\Development\_Side Project\ContactBook\DB\ContactDB.json";

        private static List<Contact> Contacts
        {
            get => ContactGenerator();
            set { }
        }

        private static List<Contact> ContactGenerator()
        {
            return new List<Contact>()
            {
                new Contact() {Id = 1, FirstName = "Wael", LastName = "Yassir", Phone = "(+20) 1021563779",
                                Email = "wy1@gmail.com", Company = "Emactus", Image = _dbPath},
                new Contact() {Id = 2, FirstName = "Waleed", LastName = "Yassir", Phone = "(+20) 1073436700",
                                Email = "yy2@gmail.com", Company = "Yoma", Image = _dbPath},
                new Contact() {Id = 3, FirstName = "Ahmed", LastName = "Osama", Phone = "(+20) 1143611048",
                                Email = "ao3@gmail.com", Company = "Luca", Image = _dbPath},
                new Contact() {Id = 4, FirstName = "Eslam", LastName = "Ibrahim", Phone = "(+20) 1514192306",
                                Email = "ei4@gmail.com", Company = "Kira", Image = _dbPath},
                new Contact() {Id = 5, FirstName = "Heba", LastName = "Ali", Phone = "(+20) 1249457123",
                                Email = "ha5@gmail.com", Company = "Fairy", Image = _dbPath},

                new Contact() {Id = 6, FirstName = "Alaa", LastName = "Hassan", Phone = "(+20) 1572617636",
                                Email = "ah6@gmail.com", Image = _dbPath},
                new Contact() {Id = 7, FirstName = "Reham", LastName = "Roshdy", Phone = "(+20) 1044125970",
                               Image = _dbPath},
                new Contact() {Id = 8, FirstName = "Mohamed", LastName = "Fikry", Phone = "(+20) 128825741",
                                Email = "mf8@gmail.com", Company = "Ruka", Image = _dbPath},
                new Contact() {Id = 9, FirstName = "Hosny", LastName = "Hassan", Phone = "(+20) 1120992378",
                                Email = "hh9@gmail.com", Image = _dbPath},
                new Contact() {Id = 10, FirstName = "Reda", LastName = "Kairy", Phone = "(+20) 1091751370",
                                Company = "Liomay", Image = _dbPath},

                new Contact() {Id = 11, FirstName = "Sara", LastName = "Abbas", Phone = "(+20) 1031689578",
                                Company = "Droplex", Image = _dbPath},
                new Contact() {Id = 12, FirstName = "Martina", LastName = "Hany", Phone = "(+20) 1526094221",
                               Image = _dbPath},
                new Contact() {Id = 13, FirstName = "Bassant", LastName = "Bassem", Phone = "(+20) 1165764042",
                                Email = "bb13@gmail.com", Image = _dbPath},
                new Contact() {Id = 14, FirstName = "Khalid", LastName = "Rabea", Phone = "(+20) 1212312781",
                                Image = _dbPath},
                new Contact() {Id = 15, FirstName = "Esraa", LastName = "Ali", Phone = "(+20) 1037005769",
                                Email = "ea15@gmail.com", Company = "IDAX", Image = _dbPath},

                new Contact() {Id = 16, FirstName = "Fares", LastName = "Roshdy", Phone = "(+20) 1168565320",
                                Company = "BAM", Image = _dbPath},
                new Contact() {Id = 17, FirstName = "Basher", LastName = "Ali", Phone = "(+20) 128857284",
                                Company = "RISA", Image = _dbPath},
                new Contact() {Id = 18, FirstName = "Ahmed", LastName = "Bary", Phone = "(+20) 1196136525",
                                Email = "ab19@gmail.com", Image = _dbPath},
                new Contact() {Id = 19, FirstName = "Rasha", LastName = "Feras", Phone = "(+20) 1282195975",
                                Image = _dbPath},
                new Contact() {Id = 20, FirstName = "Omar", LastName = "Mhamed", Phone = "(+20) 1515737927",
                                Image = _dbPath},
            };
        }

        private static string ToJson()
        {

            StringBuilder contents = new StringBuilder();
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };

            contents.Append(JsonConvert.SerializeObject(Contacts, settings));

            return contents.ToString();
        }

        public static void CreateJsonFile()
        {
            using (StreamWriter stream = new StreamWriter(_dbFileName, false))
            {
                stream.Write(ToJson());
            }
        }

        // TODO: move to the wpf app at the Repositry folder.
        public static List<Contact> ParseJsonFile()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };

            string content = File.ReadAllText(_dbFileName);
            return JsonConvert.DeserializeObject<List<Contact>>(content);
        }
    }
}
