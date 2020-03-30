using LINQ.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

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
                string data = reader.ReadToEnd();
                RootObject newData = JsonConvert.DeserializeObject<RootObject>(data);

                foreach (var item in newData.features)
                {
                    Console.WriteLine(item.properties.neighborhood);
                }
            }
        }

    }
}
