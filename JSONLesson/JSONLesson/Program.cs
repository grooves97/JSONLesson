using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;



namespace JSONLesson
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var pearson = File.Exists("pearson.json") ? JsonConvert.DeserializeObject<Pearson>(File.ReadAllText("pearson.json")) : new Pearson
    //        {
    //            age = 19,
    //            firstName = "Rassul",
    //            lastName = "Gamzatov"
    //        };

    //        pearson.age++;


    //        File.WriteAllText("pearson.json", JsonConvert.SerializeObject(pearson));

    //        //почему идет сериализация в строке 24 

    //        //string jsonData = JsonConvert.SerializeObject(pearson);

    //        //var pearson2 = JsonConvert.DeserializeObject<Pearson>(jsonData);



    //        Console.ReadLine();
    //    }
    //}






    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }

        public Person(string name, int year)
        {
            Name = name;
            Age = year;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // объект для сериализации
            Person person1 = new Person("Tom", 29);
            Person person2 = new Person("Bill", 25);
            Person[] people = new Person[] { person1, person2 };

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Person[]));

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, people);
            }

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                Person[] newpeople = (Person[])jsonFormatter.ReadObject(fs);

                foreach (Person p in newpeople)
                {
                    Console.WriteLine("Имя: {0} --- Возраст: {1}", p.Name, p.Age);
                }
            }

            Console.ReadLine();
        }
    }
}
