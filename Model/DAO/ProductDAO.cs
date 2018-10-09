using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class ProductDAO
    {
        CAYCANHNT db = null;

        public ProductDAO()
        {
            db = new CAYCANHNT();
        }

        public PRODUCT ViewDetail(int id)
        {
            return db.PRODUCTS.Find(id);
        }
    }

}
