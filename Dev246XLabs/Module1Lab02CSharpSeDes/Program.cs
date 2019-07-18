using System;
using Newtonsoft.Json;

namespace Module1Lab02CSharpSeDes
{
    internal class Program
    {
        private static void Main(String[] args)
        {
            var json = DoSerialization();
            Console.WriteLine(json);
            Console.WriteLine("\n================");
            DoDeserialization(json);
            Console.WriteLine("\n================ [ Bonus ]");
            DoDeserialization2(json);
        }

        private static String DoSerialization()
        {
            Rocket[] rockets =
            {
                new Rocket {ID = 0, Builder = "NASA", Target = "Moon", Speed = 7.8},
                new Rocket {ID = 1, Builder = "NASA", Target = "Mars", Speed = 10.9},
                new Rocket {ID = 2, Builder = "NASA", Target = "Kepler-452b", Speed = 42.1},
                new Rocket {ID = 3, Builder = "NASA", Target = "N/A", Speed = 0}
            };
            var json = JsonConvert.SerializeObject(rockets);
            return json;
        }

        private static void DoDeserialization(String json)
        {
            var rockets = JsonConvert.DeserializeObject<Rocket[]>(json);
            foreach (var r in rockets)
                Console.WriteLine($"ID:{r.ID} Builder:{r.Builder} Target:{r.Target} Speed:{r.Speed}");
        }

        private static void DoDeserialization2(String json)
        {
            var ufos = JsonConvert.DeserializeObject<UFO[]>(json);
            foreach (var ufo in ufos) Console.WriteLine($"Target:{ufo.Target} Speed:{ufo.Speed}");
        }
    }
}