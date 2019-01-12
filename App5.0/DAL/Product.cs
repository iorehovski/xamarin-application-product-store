using Java.Lang;

namespace DAL
{
    public class Product: Object
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UPC { get; set; }
        public string Producer { get; set; }
        public int Price { get; set; }
        public int ShelfLife { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(Name);
            result.Append(" ");
            result.Append(UPC);
            result.Append(" ");
            result.Append(Producer);
            result.Append(" ");
            result.Append(Price);
            result.Append(" ");
            result.Append(Count);
            result.Append(" ");
            result.Append(ShelfLife);

            return result.ToString();
        }
    }
}