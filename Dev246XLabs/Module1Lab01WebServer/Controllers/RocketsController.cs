using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Module1Lab01WebServer.Models;

namespace Module1Lab01WebServer.Controllers {
    [Route("api/[controller]")]
    public class RocketsController : Controller {
        [HttpGet]
        public Rocket[] Get() {
            return FakeData.Rockets.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int? id) {
            if (id == null) return null;
            var rocket = FakeData.Rockets.SingleOrDefault(r => r.ID == id.Value);
            return Ok(rocket);
        }
    }
}