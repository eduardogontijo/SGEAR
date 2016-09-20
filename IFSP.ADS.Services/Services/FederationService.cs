using IFSP.ADS.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;

namespace IFSP.ADS.Services.Services
{
    public class FederationService : IFederationService
    {
        public ResponseBase Create(Federation model)
        {
            var response = new ResponseBase();

            try
            {
                using (var ctx = new LusaContext())
                {
                    ctx.Federation.Add(model);

                    var result = ctx.SaveChanges();

                    if (result > 0)
                        return response;

                    response.Errors.Add(new Error { Code = 1, Description = "Não foi possível cadastrar a Federação." });
                    return response;


                    return new ResponseBase();
                }
            }
            catch (Exception ex)
            {

                response.Errors.Add(new Error { Code = 1, Message = ex.Message, Description = "Não foi possível cadastrar a Federação." });
                throw;
            }
        }

        public ResponseBase Delete(long federationID)
        {
            throw new NotImplementedException();
        }

        public Federation Get(long federationID)
        {
            var ctx = new LusaContext();

            return ctx.Federation.FirstOrDefault(x => x.Id == federationID);
        }

        public List<Federation> List()
        {
            var ctx = new LusaContext();

            return ctx.Federation.ToList();
        }

        public ResponseBase Update(Federation model)
        {
            var response = new ResponseBase();

            try
            {
                using (var ctx = new LusaContext())
                {
                    var federationDB = ctx.Federation.Single(x => x.Id == model.Id);

                    federationDB = model;

                    var result = ctx.SaveChanges();

                    if (result > 0)
                        return response;

                    response.Errors.Add(new Error { Code = 1, Description = "Não foi possível atualizar a Federação." });
                    return response;


                    return new ResponseBase();
                }
            }
            catch (Exception ex)
            {

                response.Errors.Add(new Error { Code = 1, Message = ex.Message, Description = "Não foi possível atualizar a Federação." });
                throw;
            }
        }
    }
}
