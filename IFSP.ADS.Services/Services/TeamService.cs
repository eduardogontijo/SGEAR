using IFSP.ADS.Services.Contracts;
using System;
using System.Collections.Generic;
using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;
using System.Linq;

namespace IFSP.ADS.Services.Services
{
    public class TeamService : ITeamService
    {
        private LusaContext _db;

        private void OpenConnecion()
        {
            _db = new LusaContext();
        }

        public ResponseBase Create(Team team)
        {
            var response = new ResponseBase();

            try
            {
                this.OpenConnecion();

                _db.Team.Add(team);

                var result = _db.SaveChanges();

                if (result > 0)
                    return response;
                response.Errors.Add(new Error());

                return response;

            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error() { Code = 500, Description = ex.Message, Message = "" });
                return response;
            }
        }

        public ResponseBase Delete(int teamID)
        {

            var response = new ResponseBase();

            try
            {
                this.OpenConnecion();

                var teamDb = _db.Team.Single(x => x.Id == teamID);

                return response;

            }
            catch(Exception ex)
            {
                response.Errors.Add(new Error() { Code = 500, Description = ex.Message, Message = "" });
                return response;
            }

        }

        public Team Get(int teamID)
        {
            this.OpenConnecion();
            return _db.Team.FirstOrDefault(x => x.Id == teamID);
        }

        public IList<Team> List()
        {
            this.OpenConnecion();
            return _db.Team.ToList();
        }

        public ResponseBase Update(Team team)
        {
            throw new NotImplementedException();

        }
    }
}
