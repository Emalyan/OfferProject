using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OfferProject.Data.Data;
using OfferProject.Service.Abstract;

namespace OfferProject.API.Controllers
{
    [Route("api/[controller]")]
    public class UpdateOfOfferController : Controller
    {
        private readonly IUpdateOfOfferRepository repository;

        public UpdateOfOfferController(IUpdateOfOfferRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<UpdateOfOffer> Get()
        {
            return repository.ReadAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var updateOfOffer = repository.ReadId(id);

            if (updateOfOffer != null)
            {
                return Ok(updateOfOffer);
            }

            return NotFound();
        }

        // POST api/<controller>
        [HttpPost]        
        public IActionResult Post([FromBody]Offer offer)
        {            
            //Здесь будет код с помощью каторого будет надодится авторизованный пользователь(тот кто вводит изменения)
            var updateOfOffer = new UpdateOfOffer
            {
                DateOfUpdate = DateTime.Now,
                OfferId = offer.Id,
                Updateby = 1 //id пользователя, который вводит изменения               
            };

            repository.Create(updateOfOffer);
            return Ok(updateOfOffer);
        }        

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var updateOfOffer = repository.ReadId(id);
            if(updateOfOffer != null)
            {
                repository.Delete(updateOfOffer);
                return Ok();
            }

            return NotFound();
        }
    }
}
