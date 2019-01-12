using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public static class ProductService
    {
        public static List<Product> GetAll()
        {
            return ProductSource.Items;
        }

        public static IEnumerable<Product> GetItemsByName(string name)
        {
            return ProductSource.Items.Where(x => x.Name == name);
        }

        public static IEnumerable<Product> GetItemsByName(string name, int price)
        {
            return ProductSource.Items.Where(x => x.Name == name && x.Price <= price);
        }

        public static IEnumerable<Product> GetItemsByShelfLife(int shelfLife)
        {
            return ProductSource.Items.Where(x => x.ShelfLife > shelfLife);
        }


        public static void Insert(Product item)
        {
            var last = ProductSource.Items.LastOrDefault();
            if (last != null)
            {
                item.Id = last.Id + 1;
            }
            else
            {
                item.Id = 0;
            }
            ProductSource.Items.Add(item);
        }

        public static void Remove(int id)
        {
            var item = ProductSource.Items.FirstOrDefault(x => x.Id == id);
            ProductSource.Items.Remove(item);
        }

        public static Product GetById(int id)
        {
            return ProductSource.Items.FirstOrDefault(x => x.Id == id);
        }

    }
}