using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    public static class PhoneSource
    {
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(List<Phone>));
        public static List<Phone> Items { get; private set; } = null;

        public static void ReadFromFile(string fileName)
        {
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    Items = (List<Phone>) serializer.Deserialize(reader);
                }
            }
            catch (FileNotFoundException)
            {
                Items = new List<Phone>();
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