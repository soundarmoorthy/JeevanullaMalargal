using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private IFlowersRepository flowers;
        public FlowersController()
        {
            flowers = PersistentFlowerRepository.Instance();
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Flower>> Get()
        {
            return new ActionResult<IEnumerable<Flower>>(flowers.Values);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Flower> Get(int id)
        {
            if (flowers.ContainsKey(id))
            {
                return flowers.Get(id);
            }

            return new NotFoundResult();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Flower value)
        {
            if (value == null)
                throw new InvalidOperationException("The input value is null");

            if (flowers.ContainsKey(value.Id))
            {
                this.StatusCode(409);
            }
            else
            {
                flowers.Add(value);
                this.StatusCode(StatusCodes.Status201Created);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Flower value)
        {
            if (flowers.ContainsKey(id))
            {
                flowers.Update(id, value);
                this.StatusCode(StatusCodes.Status200OK);
            }
            else
                throw new Exception($"The key doesn't exist {id}. Nothing is updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (flowers.ContainsKey(id))
            {
                flowers.Remove(id);
                this.StatusCode(StatusCodes.Status200OK);
            }
            else
                throw new KeyNotFoundException($"No item exists with Key {id}");
        }
    }
}
