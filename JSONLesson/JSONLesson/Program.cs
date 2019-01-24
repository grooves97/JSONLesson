using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;



namespace JSONLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var pearson = File.Exists("pearson.json") ? JsonConvert.DeserializeObject<Pearson>(File.ReadAllText("pearson.json")) : new Pearson
            {
                age = 19,
                firstName = "Rassul",
                lastName = "Gamzatov"
            };

            pearson.age++;

            
            File.WriteAllText("pearson.json", JsonConvert.SerializeObject(pearson));

            //почему идет сериализация в строке 24 

            //string jsonData = JsonConvert.SerializeObject(pearson);

            //var pearson2 = JsonConvert.DeserializeObject<Pearson>(jsonData);



            Console.ReadLine();
        }
    }
}
