using LINQ.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadJson();
        }

        static void ReadJson()
        {
            using (StreamReader reader = File.OpenText(@"../../../data.json"))
            {
                //JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                //Console.WriteLine(o);
                string data = reader.ReadToEnd();
                RootObject newData = JsonConvert.DeserializeObject<RootObject>(data);
                //Console.WriteLine(newData);

                // lists out all of the neighborhoods
                int count = 0;
                foreach (var item in newData.features)
                {

                    count++;
                    Console.WriteLine($"{count}: {item.properties.neighborhood}");
                }

                var queryNoName = from n in newData.features
                                  where n.properties.neighborhood != ""
                                  select n.properties.neighborhood;

                int noName = 0;
                foreach (var item in queryNoName)
                {
                    noName++;
                    Console.WriteLine($"{noName}: {item}");
                }




            }
        }

    }
}
