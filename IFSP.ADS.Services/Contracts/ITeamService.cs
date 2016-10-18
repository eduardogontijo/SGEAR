using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;
using System.Collections.Generic;

namespace IFSP.ADS.Services.Contracts
{
    public interface ITeamService
    {
        IList<Team> List();
        Team Get(int teamID);
        ResponseBase Create(Team team);
        ResponseBase Update(Team team);
        ResponseBase Delete(int teamID);
    }
}
