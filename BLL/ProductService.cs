using System;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ProductService: IDisposable
    {
        private readonly ProductContext _context;

        public ProductService(string dbPath)
        {
            _context = new ProductContext(dbPath);
            _context.Database.EnsureCreated();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetItemsByName(string name)
        {
            return _context.Products.Where(x => x.Name == name);
        }

        public IEnumerable<Product> GetItemsByName(string name, int price)
        {
            return _context.Products.Where(x => x.Name == name && x.Price <= price);
        }

        public IEnumerable<Product> GetItemsByProducer(string name)
        {
            return _context.Products.Where(x => x.Producer == name);
        }

        public IEnumerable<Product> GetItemsByShelfLife(int shelfLife)
        {
            return _context.Products.Where(x => x.ShelfLife > shelfLife);
        }

        public IEnumerable<Product> GetItemsOnStock()
        {
            return _context.Products.Where(x => x.OnStock == true);
        }


        public void Insert(Product item)
        {
            item.OnStock = true;

            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public void Update(Product item)
        {
            _context.Products.Update(item);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(item);
            _context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}