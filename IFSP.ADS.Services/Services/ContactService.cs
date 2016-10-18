using System;
using System.Collections.Generic;
using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;
using IFSP.ADS.Services.Contracts;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace IFSP.ADS.Services.Services
{
    public class ContactService : IContactService
    {
        public ResponseBase Create(Contact contact)
        {
            var response = new ResponseBase();

            try
            {
                using (var ctx = new LusaContext())
                {
                    ctx.Contact.Add(contact);

                    var result = ctx.SaveChanges();

                    if (result > 0)
                        return response;

                    response.Errors.Add(new Error { Code = 1, Description = "Não foi possível cadastrar o contato." });
                    return response;


                    return new ResponseBase();
                }
            }
            catch (Exception ex)
            {

                response.Errors.Add(new Error { Code = 1, Message = ex.Message, Description = "Não foi possível remover o contato." });
                throw;
            }
        }

        public ResponseBase Delete(int contactID)
        {
            var response = new ResponseBase();

            using (var ctx = new LusaContext())
            {

                try
                {
                    var contact = ctx.Contact.First(x => x.Id == contactID);

                    contact.Delete();

                    var result = ctx.SaveChanges();

                    if (result > 0)
                        return response;

                    response.Errors.Add(new Error { Code = 1,  Description = "Não foi possível remover o contato." });
                    return response;
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new Error { Code = 1, Message = ex.Message, Description = "Não foi possível remover o contato." });
                    throw;
                }
            }

        }

        public Contact Get(int contactID)
        {
            using (var ctx = new LusaContext())
            {
                return ctx.Contact.FirstOrDefault(x => x.Id == contactID);
            }
        }

        public IList<Contact> List()
        {
            using (var ctx = new LusaContext())
            {
                return ctx.Contact.Where(x=> x.Status).ToList();
            }
        }

        public ResponseBase Update(Contact contact)
        {
            var response = new ResponseBase();

            try
            {
                using (var ctx = new LusaContext())
                {
                    var contactDB = ctx.Contact.Single(x=> x.Id == contact.Id);
                    contactDB = contact;

                    ctx.Set<Contact>().AddOrUpdate(contactDB);

                    var result = ctx.SaveChanges();

                    if (result > 0)
                        return response;

                    response.Errors.Add(new Error { Code = 1, Description = "Não foi possível atualizar contato." });
                    return response;

                }
            }
            catch (Exception ex)
            {

                response.Errors.Add(new Error { Code = 1, Message = ex.Message, Description = "Não foi possível atualizar contato." });
                throw;
            }
        }
    }
}
