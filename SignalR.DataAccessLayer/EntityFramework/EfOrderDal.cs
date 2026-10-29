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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {

        }

        public int ActiveOrderCount()
        {
            return _context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            return _context.Orders.OrderByDescending(x => x.OrderId).Take(1).Select(x => x.TotalPrice).FirstOrDefault();
        }

        public decimal TodaysTotalPrice()
        {
            var today = DateTime.Today;
            var tomorrow = DateTime.Today.AddDays(1);

            var todaysTotalPrice = _context.Orders.Where(x => x.Description == "Hesap Kapatıldı" && (x.Date>= today && x.Date < tomorrow)).Sum(x => x.TotalPrice);

            return todaysTotalPrice;

        }

        public int TotalOrderCount()
        {
            return _context.Orders.Count();
        }
    }
}
