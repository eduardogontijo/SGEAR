using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;
using System.Collections.Generic;

namespace IFSP.ADS.Services.Contracts
{
    public interface IContactService
    {
        IList<Contact> List();
        Contact Get(int contactID);
        ResponseBase Create(Contact contact);
        ResponseBase Update(Contact contact);
        ResponseBase Delete(int contactID);
    }
}
