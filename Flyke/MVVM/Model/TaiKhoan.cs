using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flyke.MVVM.Model
{
    public class TaiKhoan
    {
        private string _id, _username, _password, _email, _displayname;
        private int _type = 4;

        public TaiKhoan() { }
        public TaiKhoan(string id, string name, string pass, int type, string email, string displayname)
        {
            _id = id;
            _username = name;
            _password = pass;
            _email = email;
            _type= type;
            _displayname = displayname;
        }
        public string id { get { return _id; } set { _id = value; } }
        public string username { get { return _username; } set { _username = value; } }
        public string password { get { return _password; } set { _password = value; } }
        public string email { get { return _email; } set { _email = value; } }
        public string displayname { get { return _displayname; } set { _displayname = value; } }
        public int type { get { return _type; } set { _type = value; } }
    }
}
