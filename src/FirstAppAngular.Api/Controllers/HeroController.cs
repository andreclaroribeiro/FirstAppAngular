using System.Collections.Generic;
using FirstAppAngular.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAppAngular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Hero>> Get()
        {
            var repository = new HeroRepository();

            return Ok(repository.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Hero> Get(int id)
        {
            var repository = new HeroRepository();
            var hero = repository.FindById(id);

            return Ok(hero);
        }

        [HttpGet("ByName")]
        public ActionResult<IEnumerable<Hero>> Get(string name)
        {
            var repository = new HeroRepository();
            var hero = repository.FindByName(name);

            return Ok(hero);
        }

        [HttpPut()]
        public ActionResult Put([FromBody] Hero hero)
        {
            var repository = new HeroRepository();
            repository.SaveOrUpdate(hero);

            return Ok();
        }

        [HttpPost]
        public ActionResult<Hero> Post([FromBody] Hero hero)
        {
            var repository = new HeroRepository();
            repository.SaveOrUpdate(hero);

            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var repository = new HeroRepository();
            repository.Delete(id);

            return Ok();
        }

    }
}