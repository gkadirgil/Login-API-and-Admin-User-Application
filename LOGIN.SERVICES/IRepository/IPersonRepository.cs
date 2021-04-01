using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIN.SERVICES
{
    public interface IPersonRepository<T> where T:class
    {
        T PersonLogin(string email, string password);
        T GetPersonWithById(int id);
        string GetPersonInfoNavBarWitById(int id);
    }
}
