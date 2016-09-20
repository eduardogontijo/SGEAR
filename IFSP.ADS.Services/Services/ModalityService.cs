using IFSP.ADS.Services.Contracts;
using System;
using System.Collections.Generic;
using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;
using System.Linq;

namespace IFSP.ADS.Services.Services
{
    public class ModalityService : IModalityService
    {
        public ResponseBase Create(Modality model)
        {
            ResponseBase response = new ResponseBase();

            int result = 0;

            try
            {
                var ctx = new LusaContext();

                ctx.Modality.Add(model);

                result = ctx.SaveChanges();

                if (result > 0)
                {
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error { Code = 1, Message = "Não foi possível salvar a modalidade", Description = ex.Message });
            }

            return response;
        }

        public Modality Get(int modalityID)
        {
            var ctx = new LusaContext();

            return ctx.Modality.FirstOrDefault(x => x.Id == modalityID);

        }

        public List<Modality> List()
        {
            var ctx = new LusaContext();

            return ctx.Modality.ToList();
        }

        public ResponseBase Update(Modality model)
        {
            ResponseBase response = new ResponseBase();

            int result = 0;

            try
            {
                var ctx = new LusaContext();

                Modality modalityDB = ctx.Modality.Single(x => x.Id == model.Id);

                modalityDB = model;

                result = ctx.SaveChanges();

                if (result > 0)
                {
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error { Code = 1, Message = "Não foi possível salvar a modalidade", Description = ex.Message });
            }

            return response;
        }
    }
}
