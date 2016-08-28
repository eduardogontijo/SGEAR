using IFSP.ADS.Models;
using IFSP.ADS.Services.Contracts;
using System.Linq;
using System.Web.Http;

namespace IFSP.ADS.API.Controllers
{
    [RoutePrefix("v1/api/category")]
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategoryService _CategoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }
        [HttpGet, Route]
        public IHttpActionResult Get(int categoryID)
        {
            var model = _CategoryService.Get(categoryID);

            if (model != null)
                return Ok(model);

            return NotFound();
        }

        [HttpGet, Route]
        public IHttpActionResult All()
        {
            var model = _CategoryService.List();

            if (model != null && model.Count > 0)
                return Ok(model);

            return NotFound();
        }

        [HttpDelete, Route]
        public IHttpActionResult Delete(int categoryID)
        {
            var model = _CategoryService.Delete(categoryID);

            return BadRequest(model.Errors.FirstOrDefault().Message);
        }

        [HttpPut, Route]
        public IHttpActionResult Update(Category category)
        {
            var model = _CategoryService.Update(category);

            return BadRequest(model.Errors.FirstOrDefault().Message);
        }

        [HttpPost, Route]
        public IHttpActionResult Create(Category category)
        {
            var model = _CategoryService.Create(category);

            return BadRequest(model.Errors.FirstOrDefault().Message);
        }

    }
}