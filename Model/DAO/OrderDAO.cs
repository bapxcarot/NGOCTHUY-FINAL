using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class OrderDAO
    {
        CAYCANHNT db = null;

        public OrderDAO()
        {
            db = new CAYCANHNT();
        }

        public int Insert(ORDER order)
        {
            db.ORDERs.Add(order);
            db.SaveChanges();
            return order.ID_CART;
        }
    }
}
