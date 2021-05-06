using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestListViewPersistence.Persistence
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static List<Person> LoadFromJson()
        {
            var json = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "persistedData.json"));

            //this could crash if the json is malformed
            List<Person> people = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(json);
            

            return people;
        }


        public static void SaveList(List<Person> people)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(people);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "persistedData.json"), json);
        }
    }
}
