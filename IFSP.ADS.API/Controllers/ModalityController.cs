using IFSP.ADS.Infrastructure;
using IFSP.ADS.Models;
using IFSP.ADS.Services.Contracts;
using System.Web.Http;

namespace IFSP.ADS.API.Controllers
{
    [RoutePrefix("v1/api/modality")]
    public class ModalityController : ApiControllerBase
    {
        private readonly IModalityService _service;

        public ModalityController(IModalityService service)
        {
            _service = service;
        }

        [HttpGet, Route]
        public IHttpActionResult Get([FromUri]int modalityID)
        {
            var result = _service.Get(modalityID);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost, Route]
        public IHttpActionResult Create([FromBody]Modality model)
        {
            ResponseBase response = _service.Create(model);

            if (response.HasError)
                return BadRequest(response.Errors[0].Description);
            return Ok();
        }

        [HttpDelete, Route]
        public IHttpActionResult Delete(int modalityID)
        {
            var model = _service.Delete(modalityID);

            if (!model.HasError)
                return Ok();
            return BadRequest(model.Errors[0].Description);
        }

        [HttpPut, Route]
        public IHttpActionResult Update([FromBody]Modality model)
        {
            ResponseBase response = _service.Update(model);

            if (response.HasError)
                return BadRequest(response.Errors[0].Description);
            return Ok();
        }

        [HttpGet, Route]
        public IHttpActionResult Get()
        {
            var result = _service.List();

            if (result != null)
                return Ok(result);

            return NotFound();
        }
    }

}