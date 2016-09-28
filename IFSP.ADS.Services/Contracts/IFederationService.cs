using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;
using System.Collections.Generic;

namespace IFSP.ADS.Services.Contracts
{
    public interface IFederationService
    {
        ResponseBase Create(Federation model);
        ResponseBase Update(Federation model);
        ResponseBase Delete(long federationID);
        Federation Get(long federationID);
        List<Federation> List();
    }

}
