using IBKS.Managers.Interfaces;
using IBKS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace IBKS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TModel> : ControllerBase where TModel : ApiModel
    {
        protected abstract IBaseManager<TModel> GetManager();

        // GET: api/<BaseController>
        [HttpGet]
        public virtual IEnumerable<TModel> Get()
        {
            return GetManager().GetAll();
        }

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public virtual TModel Get(int id)
        {
            return GetManager().GetById(id);
        }

        // POST api/<BaseController>
        [HttpPost]
        public virtual TModel Save([FromBody] TModel model)
        {
            return GetManager().Save(model);
        }

        // PUT api/<BaseController>/5
        [HttpPut]
        public virtual TModel Put([FromBody] TModel model)
        {
            return GetManager().Save(model);
        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public virtual void Delete(int id)
        {
            GetManager().Delete(id);
        }
    }
}
