using System;
using System.Collections.Generic;
using System.Text;

namespace APIDomain.Entities
{
    public class Notifier
    {
        public string Error { get; private set; }

        public Notifier(string error)
        {
            Error = error;
        }
    }
}
