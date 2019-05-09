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
        private readonly IUpdateOfOfferRepository updateOfOfferRepository;

        public UpdateOfOfferController(IUpdateOfOfferRepository updateOfOfferRepository)
        {
            this.updateOfOfferRepository = updateOfOfferRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<UpdateOfOffer> Get()
        {
            return updateOfOfferRepository.UpdatesOfOffers;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var updateOfOffer = updateOfOfferRepository.ReadId(id);

            if (updateOfOffer != null)
            {
                return Ok(updateOfOffer);
            }

            return NotFound();
        }

        // POST api/<controller>
        [HttpPost("{id}")]
        public IActionResult Post(long offerId)
        {            
            //Здесь будет код с помощью каторого будет надодится авторизованный пользователь(тот кто вводит изменения)

            var updateOfOffer = new UpdateOfOffer
            {
                DateOfUpdate = DateTime.Now,
                OfferId = offerId,
                Updateby = 1 //id пользователя, который вводит изменения               
            };

            updateOfOfferRepository.Create(updateOfOffer);
            return Ok();
        }        

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var updateOfOffer = updateOfOfferRepository.ReadId(id);
            if(updateOfOffer != null)
            {
                updateOfOfferRepository.Delete(updateOfOffer);
                return Ok();
            }

            return NotFound();
        }
    }
}
