using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    public static class ProductSource
    {
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

        public static List<Product> Items { get; set; } = new List<Product>();

        public static void ReadFromFile(string fileName)
        {
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    Items = (List<Product>)serializer.Deserialize(reader);
                }
            }
            catch (FileNotFoundException)
            {
                Items = new List<Product>();
            }
        }

        public static void WriteToFile(string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, Items);
            }
        }
    }
}