using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class OrderDetailDAO
    {
        CAYCANHNT db = null;

        public OrderDetailDAO()
        {
            db = new CAYCANHNT();
        }

        public bool Insert(ORDER_DETAIL detail)
        {
            try
            {
                db.ORDER_DETAIL.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
