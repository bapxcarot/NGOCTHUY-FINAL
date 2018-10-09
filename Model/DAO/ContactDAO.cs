using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ContactDAO
    {
        CAYCANHNT db = null;

        public ContactDAO()
        {
            db = new CAYCANHNT();
        }

        public int InsertContact(CONTACT ct)
        {
            db.CONTACTs.Add(ct);
            db.SaveChanges();
            return ct.id;
        }
    }
}
