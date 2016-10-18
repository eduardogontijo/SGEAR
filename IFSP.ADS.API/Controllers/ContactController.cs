using IFSP.ADS.Models;
using IFSP.ADS.Services.Contracts;
using System.Linq;
using System.Web.Http;

namespace IFSP.ADS.API.Controllers
{
    [RoutePrefix("v1/api/contact")]
    public class ContactController : ApiControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactController(IContactService contactService)
        {
            _ContactService = contactService;
        }
        [HttpGet, Route]
        public IHttpActionResult Get(int contactID)
        {
            var model = _ContactService.Get(contactID);

            if (model != null)
                return Ok(model);

            return NotFound();
        }

        [HttpGet, Route]
        public IHttpActionResult All()
        {
            var model = _ContactService.List();

            if (model != null)
                return Ok(model);

            return NotFound();
        }

        [HttpDelete, Route]
        public IHttpActionResult Delete(int contactID)
        {
            var model = _ContactService.Delete(contactID);

            if (!model.HasError)
                return Ok();
            return BadRequest(model.Errors.FirstOrDefault().Message);
        }

        [HttpPut, Route]
        public IHttpActionResult Update(Contact contact)
        {
            var model = _ContactService.Update(contact);

            if (!model.HasError)
                return Ok();

            return BadRequest(model.Errors.FirstOrDefault().Message);
        }

        [HttpPost, Route]
        public IHttpActionResult Create(Contact contact)
        {
            var model = _ContactService.Create(contact);

            if (!model.HasError)
                return Ok();

            return BadRequest(model.Errors.FirstOrDefault().Message);
        }

    }
}