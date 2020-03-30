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
                string data = reader.ReadToEnd();
                RootObject newData = JsonConvert.DeserializeObject<RootObject>(data);
                //Console.WriteLine(newData);

                // lists out all of the neighborhoods
                int count = 0;
                foreach (var item in newData.features)
                {

                    count++;
                    //Console.WriteLine($"{count}: {item.properties.neighborhood}");
                }


                // queries to select all the neighborhoods with no names
                var query = from n in newData.features
                                  where n.properties.neighborhood != ""
                                  select n.properties.neighborhood;

                // using the queryNoName query, this will console write all of the no named neighborhoods
                int noName = 0;
                foreach (var item in query)
                {
                    noName++;
                    //Console.WriteLine($"{noName}: {item}");
                }

                // queries for no duplicates
                var noDupes = query.Distinct();

                int noDupesCount = 0;
                foreach (var item in noDupes)
                {
                    noDupesCount++;
                    //Console.WriteLine($"{noDupesCount}: {item}");
                }

                //this is just one query that does all 3 of the above queries
                var allQueries = (from neighbor in newData.features
                                  where neighbor.properties.neighborhood != ""
                                  select neighbor.properties.neighborhood)
                                  .Distinct();

                foreach (var item in allQueries)
                {
                    Console.WriteLine(item);
                }








            }
        }

    }
}
