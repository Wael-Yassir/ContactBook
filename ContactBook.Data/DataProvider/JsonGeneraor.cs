﻿using System.IO;
using System.Text;
using Newtonsoft.Json;
using ContactBook.Data.Models;
using System.Collections.Generic;

namespace ContactBook.Data.DataProvider
{
    public static class JsonGeneraor
    {
        private static readonly string _dbPath = 
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\DB";

        private static readonly string _dbFileName = _dbPath + @"\ContactDB.json";
        public static string DbFileName
        {
            get { return _dbFileName; }
        }


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
                                Email = "wy1@gmail.com", Company = "Emactus"},
                new Contact() {Id = 2, FirstName = "Waleed", LastName = "Yassir", Phone = "(+20) 1073436700",
                                Email = "yy2@gmail.com", Company = "Yoma"},
                new Contact() {Id = 3, FirstName = "Ahmed", LastName = "Osama", Phone = "(+20) 1143611048",
                                Email = "ao3@gmail.com", Company = "Luca"},
                new Contact() {Id = 4, FirstName = "Eslam", LastName = "Ibrahim", Phone = "(+20) 1514192306",
                                Email = "ei4@gmail.com", Company = "Kira"},
                new Contact() {Id = 5, FirstName = "Heba", LastName = "Ali", Phone = "(+20) 1249457123",
                                Email = "ha5@gmail.com", Company = "Fairy"},

                new Contact() {Id = 6, FirstName = "Alaa", LastName = "Hassan", Phone = "(+20) 1572617636",
                                Email = "ah6@gmail.com"},
                new Contact() {Id = 7, FirstName = "Reham", LastName = "Roshdy", Phone = "(+20) 1044125970",
                               },
                new Contact() {Id = 8, FirstName = "Mohamed", LastName = "Fikry", Phone = "(+20) 128825741",
                                Email = "mf8@gmail.com", Company = "Ruka"},
                new Contact() {Id = 9, FirstName = "Hosny", LastName = "Hassan", Phone = "(+20) 1120992378",
                                Email = "hh9@gmail.com"},
                new Contact() {Id = 10, FirstName = "Reda", LastName = "Kairy", Phone = "(+20) 1091751370",
                                Company = "Liomay"},

                new Contact() {Id = 11, FirstName = "Sara", LastName = "Abbas", Phone = "(+20) 1031689578",
                                Company = "Droplex"},
                new Contact() {Id = 12, FirstName = "Martina", LastName = "Hany", Phone = "(+20) 1526094221",
                               },
                new Contact() {Id = 13, FirstName = "Bassant", LastName = "Bassem", Phone = "(+20) 1165764042",
                                Email = "bb13@gmail.com"},
                new Contact() {Id = 14, FirstName = "Khalid", LastName = "Rabea", Phone = "(+20) 1212312781",
                                },
                new Contact() {Id = 15, FirstName = "Esraa", LastName = "Ali", Phone = "(+20) 1037005769",
                                Email = "ea15@gmail.com", Company = "IDAX"},

                new Contact() {Id = 16, FirstName = "Fares", LastName = "Roshdy", Phone = "(+20) 1168565320",
                                Company = "BAM"},
                new Contact() {Id = 17, FirstName = "Basher", LastName = "Ali", Phone = "(+20) 128857284",
                                Company = "RISA"},
                new Contact() {Id = 18, FirstName = "Ahmed", LastName = "Bary", Phone = "(+20) 1196136525",
                                Email = "ab19@gmail.com"},
                new Contact() {Id = 19, FirstName = "Rasha", LastName = "Feras", Phone = "(+20) 1282195975",
                                },
                new Contact() {Id = 20, FirstName = "Omar", LastName = "Mhamed", Phone = "(+20) 1515737927",
                                },
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

        internal static void CreateJsonFile()
        {
            using (StreamWriter stream = new StreamWriter(_dbFileName, false))
            {
                stream.Write(ToJson());
            }
        }

        public static void CreateJsonFile(List<Contact> contacts)
        {
            StringBuilder contents = new StringBuilder();
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };

            contents.Append(JsonConvert.SerializeObject(contacts, settings));

            if (File.Exists(_dbFileName))
            {
                File.Delete(_dbFileName);
            }

            using (StreamWriter stream = new StreamWriter(_dbFileName, false))
            {
                stream.Write(contents.ToString());
            }
        }
    }
}
