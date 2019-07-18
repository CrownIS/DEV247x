using System;
using Newtonsoft.Json;

namespace Module1Lab01CSharpSelfAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Serialize
            var product1 = new Product()
            {
                ID = 1,
                Name = "Laptop",
                Price = 1024.22
            };

            var json = JsonConvert.SerializeObject(product1);
            Console.WriteLine("Product (Json):");
            Console.WriteLine(json);

            // Deserialize
            var product2 = JsonConvert.DeserializeObject(json, typeof(Product));
            Console.WriteLine("\nProduct (object):");
            Console.WriteLine(product2.ToString());
        }
    }
}
