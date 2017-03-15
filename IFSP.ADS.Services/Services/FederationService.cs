using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;
using IFSP.ADS.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var response = new ResponseBase();

            using (var ctx = new LusaContext())
            {

                try
                {
                    var federation = ctx.Federation.First(x => x.Id == federationID);

                    federation.Delete();

                    var result = ctx.SaveChanges();

                    if (result > 0)
                        return response;

                    response.Errors.Add(new Error { Code = 1, Description = "Não foi possível remover a federação." });
                    return response;
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new Error { Code = 1, Message = ex.Message, Description = "Não foi possível remover a federação." });
                    throw;
                }
            }
        }

        public Federation Get(long federationID)
        {
            var ctx = new LusaContext();

            return  ctx.Federation.Include("Contact").Include("Address").FirstOrDefault(x => x.Id == federationID);
           
        }

        public List<Federation> List()
        {
            var ctx = new LusaContext();

            return ctx.Federation.Where(x => x.Status).ToList();
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

                    ctx.Set<Federation>().AddOrUpdate(federationDB);

                    var result = ctx.SaveChanges();

                    if (result > 0)
                        return response;

                    response.Errors.Add(new Error { Code = 1, Description = "Não foi possível atualizar federação." });
                    return response;

                }
            }
            catch (Exception ex)
            {

                response.Errors.Add(new Error { Code = 1, Message = ex.Message, Description = "Não foi possível atualizar federação." });
                throw;
            }
        }
    }

}
