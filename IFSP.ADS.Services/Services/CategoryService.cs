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
    public class CategoryService : ICategoryService
    {
        public ResponseBase Create(Category category)
        {
            var response = new ResponseBase();

            try
            {
                using (var ctx = new LusaContext())
                {
                    ctx.Category.Add(category);

                    var result = ctx.SaveChanges();

                    if (result > 0)
                        return response;

                    response.Errors.Add(new Error { Code = 1, Description = "Não foi possível cadastrar a categoria." });
                    return response;


                    return new ResponseBase();
                }
            }
            catch (Exception ex)
            {

                response.Errors.Add(new Error { Code = 1, Message = ex.Message, Description = "Não foi possível remover a categoria." });
                throw;
            }
        }

        public ResponseBase Delete(int categoryID)
        {
            var response = new ResponseBase();

            using (var ctx = new LusaContext())
            {

                try
                {
                    var category = ctx.Category.First(x => x.Id == categoryID);

                    category.Delete();

                    var result = ctx.SaveChanges();

                    if (result > 0)
                        return response;

                    response.Errors.Add(new Error { Code = 1,  Description = "Não foi possível remover a categoria." });
                    return response;
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new Error { Code = 1, Message = ex.Message, Description = "Não foi possível remover a categoria." });
                    throw;
                }
            }

        }

        public Category Get(int categoryID)
        {
            using (var ctx = new LusaContext())
            {
                return ctx.Category.FirstOrDefault(x => x.Id == categoryID);
            }
        }

        public IList<Category> List()
        {
            using (var ctx = new LusaContext())
            {
                return ctx.Category.Where(x=> x.Status).ToList();
            }
        }

        public ResponseBase Update(Category category)
        {
            var response = new ResponseBase();

            try
            {
                using (var ctx = new LusaContext())
                {
                    var categoryDB = ctx.Category.Single(x=> x.Id == category.Id);
                    categoryDB = category;

                    ctx.Set<Category>().AddOrUpdate(categoryDB);

                    var result = ctx.SaveChanges();

                    if (result > 0)
                        return response;

                    response.Errors.Add(new Error { Code = 1, Description = "Não foi possível atualizar a categoria." });
                    return response;

                }
            }
            catch (Exception ex)
            {

                response.Errors.Add(new Error { Code = 1, Message = ex.Message, Description = "Não foi possível atualizar a categoria." });
                throw;
            }
        }
    }
}
