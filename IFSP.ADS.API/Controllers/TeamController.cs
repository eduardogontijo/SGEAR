using IFSP.ADS.Models;
using IFSP.ADS.Services.Contracts;
using IFSP.ADS.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace IFSP.ADS.API.Controllers
{
    [RoutePrefix("api/v1/team")]
    public class TeamController:ApiControllerBase
    {
        private readonly ITeamService _service;

        public TeamController(ITeamService service)
        {
            _service = service;
        }

        [HttpGet, Route]
        public IHttpActionResult Get(int teamID)
        {
            var model = _service.Get(teamID);

            if (model != null)
                return Ok(model);

            return NotFound();
        }

        [HttpGet, Route]
        public IHttpActionResult All()
        {
            var model = _service.List();

            if (model != null && model.Count > 0)
                return Ok(model);

            return NotFound();
        }

        [HttpDelete, Route]
        public IHttpActionResult Delete(int teamID)
        {
            var model = _service.Delete(teamID);

            if (!model.HasError)
                return Ok();
            return BadRequest(model.Errors.FirstOrDefault().Message);
        }

        [HttpPut, Route]
        public IHttpActionResult Update(Team team)
        {
            var model = _service.Update(team);

            if (!model.HasError)
                return Ok();

            return BadRequest(model.Errors.FirstOrDefault().Message);
        }

        [HttpPost, Route]
        public IHttpActionResult Create(Team team)
        {
            var model = _service.Create(team);

            if (!model.HasError)
                return Ok();

            return BadRequest(model.Errors.FirstOrDefault().Message);
        }

    }
}