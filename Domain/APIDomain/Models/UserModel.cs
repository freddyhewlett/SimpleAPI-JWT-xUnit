using System;
using System.Collections.Generic;
using System.Text;

namespace APIDomain.Models
{
    public class UserModel
    {
        private Guid _id;
        private string _name;
        private string _email;
        private DateTime _creatDate;
        private DateTime _updateDate;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public DateTime CreateDate
        {
            get { return _creatDate; }
            set { _creatDate = value == null ? DateTime.Now : value; }
        }
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
    }
}
