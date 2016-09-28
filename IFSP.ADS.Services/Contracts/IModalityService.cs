using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;
using System.Collections.Generic;

namespace IFSP.ADS.Services.Contracts
{
    public interface IModalityService
    {
        ResponseBase Create(Modality model);
        ResponseBase Update(Modality model);
        List<Modality> List();
        Modality Get(int modalityID);
    }

}
