using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OfferProject.Data.Data;
using OfferProject.Service.Abstract;

namespace OfferProject.API.Controllers
{
    [Route("api/[controller]")]
    public class OffersController : Controller
    {
        private readonly IOfferRepository repository;        

        public OffersController(IOfferRepository repository)
        {
            this.repository = repository;            
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Offer> Get()
        {            
            return repository.ReadAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var offer = repository.ReadId(id);
            if(offer != null)
            {
                return new ObjectResult(offer);
            }
            return NotFound();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Offer offer)
        {
            //var userName = User.Identity.Name;
            //var user = userRepository.ReadByName(username);

            if (ModelState.IsValid)
            {
                if (offer != null)
                {
                    offer.DateOfCreate = DateTime.Now;
                    offer.CustomerId = 1; //user.Id; исполнитель(создатель - аторизованный пользователь)                    
                    repository.Create(offer);
                    return Ok(offer);
                }
            }            
            return BadRequest();
        }

        // PUT api/<controller>
        [HttpPut]
        public IActionResult Put([FromBody]Offer offer)
        {
            if (ModelState.IsValid)
            {
                var updatedOffer = repository.ReadId(offer.Id);
                if (updatedOffer != null)
                {
                    updatedOffer.ExploreId = offer.ExploreId;
                    //код с введением изменения
                    repository.Update(updatedOffer);
                    return Ok(updatedOffer);
                }
                return NotFound();
            }
            return BadRequest();            
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var offer = repository.ReadId(id);
            if(offer != null)
            {
                repository.Delete(offer);
                return Ok();
            }
            return NotFound();
        }
    }
}
