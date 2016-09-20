using IFSP.ADS.Models;
using IFSP.ADS.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace IFSP.ADS.API.Controllers
{
    [RoutePrefix("v1/api/")]
    public class FederationController : ApiControllerBase
    {
        private readonly IFederationService _service;

        public FederationController(IFederationService service)
        {
            _service = service;
        }

        [HttpGet, Route("")]
        public IHttpActionResult Get([FromUri]long federationID)
        {

            var response = _service.Get(federationID);

            if (response != null)

                return Ok(response);
            return NotFound();
        }

        [HttpGet, Route("")]
        public IHttpActionResult List([FromUri]long federationID)
        {

            var response = _service.List();

            if (response != null && response.Any())
                return Ok(response);

            return NotFound();
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create(Federation model)
        {

            var response = _service.Create(model);

            if (!response.HasError)
                return Ok();

            return BadRequest();
        }

        [HttpGet, Route("")]
        public IHttpActionResult Update(Federation model)
        {

            var response = _service.Update(model);

            if (!response.HasError)
                return Ok();

            return BadRequest();
        }

        [HttpGet, Route("")]
        public IHttpActionResult Delete([FromUri]long federationID)
        {

            var response = _service.Delete(federationID);

            if (!response.HasError)
                return Ok();

            return BadRequest();
        }


    }
}