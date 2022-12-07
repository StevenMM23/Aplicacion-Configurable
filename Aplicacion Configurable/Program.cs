using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aplicacion_Configurable
{
    internal class Program
    {
        private static string _path = @"C:\Users\estev\Desktop\New folder\VisualReact\Aplicacion Configurable\Aplicacion Configurable\Contacts.json";
        static void Main(string[] args)
        {
            //var contacts = GetContacts();
            //SerializeJsonFile(contacts);

            var contacts = GetContactsJsonFromFile();
            var contactsDeserialize = DeserializeJsonFile(contacts);

            Console.WriteLine(contactsDeserialize[0].Name);

            Console.ReadKey();

        }

        public static string GetContactsJsonFromFile()
        {
            string contactsJsonFromFile;
            using (var reader = new StreamReader(_path))
            {
                contactsJsonFromFile = reader.ReadToEnd();
            }

            return contactsJsonFromFile;
        }

        public static List<Contact> DeserializeJsonFile(string contactsJsonFromFile)
        {
            // Console.WriteLine(contactsJsonFromFile);
            var contacts = JsonConvert.DeserializeObject<List<Contact>>(contactsJsonFromFile);

            return contacts;
        }
        public static void SerializeJsonFile(List<Contact> contacts)
        {
            string contactsJson = JsonConvert.SerializeObject(contacts.ToArray(), Formatting.Indented);
            File.WriteAllText(_path, contactsJson);
        }
        public static List<Contact> GetContacts()
        {
            var contacts = new List<Contact>
            {
                new Contact
                {
                    Name = "John Wick",
                    DateOfBirth = new DateTime(1980, 05,17),
                    Address = new Address
                    {
                        Street = "Centennial Dr",
                        Number = 15,
                        City = new City
                        {
                            Name = "Chicago",
                            Country = new Country
                            {
                                Code = "USA", Name = "United States"
                            }
                        }
                    },
                    Phones = new List<Phone>
                    {
                        new Phone{ Name = "Personal", Number = "282304802"},
                        new Phone{ Name = "Work", Number = "12341235145"}
                    }

                },
                new Contact
                {
                Name = "Alfred Hitchchok",
                DateOfBirth = new DateTime(1990, 05,17),
                Address = new Address
                {
                    Street = "Av. Mariscal la Mar",
                    Number = 15,
                    City = new City
                    {
                        Name = "Las Vegas",
                        Country = new Country
                        {
                            Code = "USA", Name = "United States"
                        }
                    }
                },
                Phones = new List<Phone>
                {
                    new Phone{ Name = "Personal", Number = "282304802"},
                    new Phone{ Name = "Work", Number = "12341235145"}
                }

            }
            };
            return contacts;
        }
    }

    public class Address
    {
        public string Street { get; set; }
        public int Number { get; set; }

        public City City { get; set; }
    }

    public class Phone
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public Country Country { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }

    }

}
