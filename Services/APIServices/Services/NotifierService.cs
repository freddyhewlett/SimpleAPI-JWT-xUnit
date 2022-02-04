using APIDomain.Entities;
using APIDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIServices.Services
{
    public class NotifierService : INotifierService
    {
        private List<Notifier> errorList = new List<Notifier>();

        public NotifierService() { }

        public void AddError(string error)
        {
            errorList.Add(new Notifier(error));
        }

        public IEnumerable<Notifier> AllErrors()
        {
            return errorList;
        }

        public bool HasError()
        {
            return errorList.Any();
        }
    }
}
