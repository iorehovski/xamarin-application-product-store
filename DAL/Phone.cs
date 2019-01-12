using Java.Lang;

namespace DAL
{
    public class Phone : Object
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int TownCallsTime { get; set; }
        public int IntersityCallsTime { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(Surname);
            result.Append(" ");
            result.Append(Name);
            result.Append(" ");
            result.Append(LastName);
            result.Append(" ");
            result.Append(Address);
            result.Append(" ");
            result.Append(TownCallsTime);
            result.Append(" ");
            result.Append(IntersityCallsTime);

            return result.ToString();
        }
    }
}