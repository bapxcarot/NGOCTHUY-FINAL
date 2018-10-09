using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserDAO
    {
        CAYCANHNT _db = null;

        public UserDAO()
        {
            _db = new CAYCANHNT();
        }

        public long Insert(USER entity)
        {
            _db.USERS.Add(entity);
            _db.SaveChanges();
            return entity.ID_USERS;
        }

        public USER GetByID(string username)
        {
            return _db.USERS.SingleOrDefault(x => x.USERNAME == username);
        }

        public int Login(string UserName, string PassWord)
        {
            var result = _db.USERS.SingleOrDefault(x => x.USERNAME == UserName);
            if (result == null)
            {
                return 0;   // tai khoan khong ton tai
            }
            else
            {
                if (result.HIDE == 1)
                {
                    return -1;   //tai khoan bi khoa
                }
                else
                {
                    if (result.PASSWORD == PassWord)
                    {
                        return 1;   // dang nhap thanh cong
                    }
                    else
                    {
                        return -2;  // sai mat khau
                    }
                }
            }
        }

        public bool CheckUserName(string username)
        {
            return _db.USERS.Count(x => x.USERNAME == username) > 0;
        }

        public bool CheckEmail(string email)
        {
            return _db.USERS.Count(x => x.EMAIL == email) > 0;
        }
    }
}
