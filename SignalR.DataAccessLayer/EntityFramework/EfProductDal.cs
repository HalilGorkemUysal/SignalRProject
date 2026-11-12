using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var values = _context.Products.Include(x => x.Category).ToList();

            return values;
        }

        public int ProductCount()
        {
            return _context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            return _context.Products.Where(x => x.CategoryId == (_context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryId).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            return _context.Products.Where(x => x.CategoryId == (_context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryId).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            var productName = _context.Products.OrderByDescending(x => x.Price).Select(x => x.ProductName).FirstOrDefault();

            return productName;
        }

        public string ProductNameByMinPrice()
        {
            var productName = _context.Products.OrderBy(x => x.Price).Select(x => x.ProductName).FirstOrDefault();

            return productName;
        }

        public decimal ProductPriceAvg()
        {
            var avgPrice = _context.Products.Average(x => x.Price);

            return avgPrice;
        }

        public decimal AvgPriceOfHamburgers()
        {
            var hamburgerId = _context.Categories.Where(x => x.CategoryName == "Hamburger").Select(x => x.CategoryId).FirstOrDefault();

            var avgBurgerOPrice = _context.Products.Where(x => x.CategoryId == hamburgerId).Average(x => x.Price);

            return avgBurgerOPrice;
        }

        public List<Product> GetLast9Products()
        {
            var products = _context.Products.Take(9).ToList();
            return products;
        }
    }
}
