using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountSOAP
{
    public class AccountDAO
    {
        private static String strCon = "SERVER=den1.mssql7.gear.host;DATABASE=saaccount;USER=saaccount;PASSWORD=Cv2dtMws57-?";
        private AccountDBDataContext db = new AccountDBDataContext(strCon);
        public bool AddUser(account newAcc)
        {
            var userAdd = from p in db.accounts where p.username == newAcc.username select p;
            if (userAdd.Any())
            {
                return false;
            }
            else
            {
                db.accounts.InsertOnSubmit(newAcc);
                db.SubmitChanges();
                return true;
            }
        }
        public bool Login(string username, string password)
        {
            var userlogin = from p in db.accounts where p.username == username && p.password == password select p;
            if (userlogin.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckAccount(string username)
        {
            var users_finded = from nd in db.accounts where nd.username == username select nd;
            if (users_finded.Any())
            {
                return true;
            }
            else { return false; }
        }
    }
}