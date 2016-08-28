using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;
using System.Collections.Generic;

namespace IFSP.ADS.Services.Contracts
{
    public interface ICategoryService
    {
        IList<Category> List();
        Category Get(int categoryID);
        ResponseBase Create(Category category);
        ResponseBase Update(Category category);
        ResponseBase Delete(int categoryID);
    }
}
