using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module2Lab01RocketsWebServer.Models;

namespace Module2Lab01RocketsWebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RocketsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(FakeData.Rockets.Values.ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (FakeData.Rockets.ContainsKey(id))
            {
                return Ok(FakeData.Rockets[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]Rocket rocket)
        {
            if (!this.ModelState.IsValid || rocket == null)
            {
                return BadRequest();
            }
            else
            {
                var maxExistingID = 0;
                if (FakeData.Rockets.Count > 0)
                {
                    maxExistingID = FakeData.Rockets.Keys.Max();
                }

                rocket.ID = maxExistingID + 1;
                FakeData.Rockets.Add(rocket.ID, rocket);

                return Created($"api/rockets/{rocket.ID}", rocket);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Rocket rocket)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            else if (FakeData.Rockets.ContainsKey(id))
            {
                FakeData.Rockets[id] = rocket;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (FakeData.Rockets.ContainsKey(id))
            {
                FakeData.Rockets.Remove(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}