using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public static class PhoneService
    {
        public static List<Phone> GetAll()
        {
            return PhoneSource.Items;
        }

        public static IEnumerable<Phone> GetSortedByName()
        {
            return PhoneSource.Items.OrderBy(x => x.Surname);
        }

        public static IEnumerable<Phone> GetIntersityCallsUsed()
        {
            return PhoneSource.Items.Where(x => x.IntersityCallsTime != 0);
        }

        public static IEnumerable<Phone> GetTownCallsUsed(int minTime)
        {
            return PhoneSource.Items.Where(x => x.TownCallsTime > minTime);
        }

        public static void Insert(Phone item)
        {
            var last = PhoneSource.Items.LastOrDefault();
            if (last != null)
            {
                item.Id = last.Id + 1;
            }
            else
            {
                item.Id = 0;
            }
            PhoneSource.Items.Add(item);
        }

        public static void Remove(int id)
        {
            var item = PhoneSource.Items.FirstOrDefault(x => x.Id == id);
            PhoneSource.Items.Remove(item);
        }

        public static Phone GetById(int id)
        {
            return PhoneSource.Items.FirstOrDefault(x => x.Id == id);
        }
    }
}
