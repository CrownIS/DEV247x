﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module2Lab01WebServer.Models;

namespace Module2Lab01WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Repository.Products.Values.ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (Repository.Products.ContainsKey(id))
            {
                return Ok(Repository.Products[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {
            if (!this.ModelState.IsValid || product == null)
            {
                return BadRequest();
            }
            else
            {
                var maxExistingID = 0;
                if (Repository.Products.Count > 0)
                {
                    maxExistingID = Repository.Products.Keys.Max();
                }

                product.ID = maxExistingID + 1;
                Repository.Products.Add(product.ID, product);

                return Created($"api/products/{product.ID}", product);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Product product)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            else if (Repository.Products.ContainsKey(id))
            {
                Repository.Products[id] = product;
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
            if (Repository.Products.ContainsKey(id))
            {
                Repository.Products.Remove(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}