using System;
using System.Collections.Generic;
using System.Text;

namespace APIDomain.Entities.User
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
