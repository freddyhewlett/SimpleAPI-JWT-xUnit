using APIDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIDomain.Interfaces.Services
{
    public interface INotifierService
    {
        void AddError(string error);

        bool HasError();

        IEnumerable<Notifier> AllErrors();
    }
}
