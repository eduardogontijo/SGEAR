using IFSP.ADS.Models;
using IFSP.ADS.Services.Contracts;
using System.Linq;
using System.Web.Http;

namespace IFSP.ADS.API.Controllers
{

    [RoutePrefix("v1/api/federation")]
    public class FederationController : ApiControllerBase
    {
        private readonly IFederationService _service;

        public FederationController(IFederationService service)
        {
            _service = service;
        }

        [HttpGet, Route]
        public IHttpActionResult Get(int federationID)
        {

            var response = _service.Get(federationID);

            if (response != null)

                return Ok(response);
            return NotFound();
        }

        [HttpGet, Route]
        public IHttpActionResult All()
        {

            var response = _service.List();

            if (response != null)
                return Ok(response);

            return NotFound();
        }

        [HttpPost, Route]
        public IHttpActionResult Create(Federation model)
        {

            var response = _service.Create(model);

            if (!response.HasError)
                return Ok();

            return BadRequest();
        }

        [HttpPut, Route]
        public IHttpActionResult Update(Federation model)
        {

            var response = _service.Update(model);

            if (!response.HasError)
                return Ok();

            return BadRequest();
        }

        [HttpDelete, Route]
        public IHttpActionResult Delete(int federationID)
        {

            var response = _service.Delete(federationID);

            if (!response.HasError)
                return Ok();

            return BadRequest();
        }

    }

}