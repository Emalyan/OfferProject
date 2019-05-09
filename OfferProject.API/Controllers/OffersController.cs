using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OfferProject.Data.Data;
using OfferProject.Service.Abstract;

namespace OfferProject.API.Controllers
{
    [Route("api/[controller]")]
    public class OffersController : Controller
    {
        private readonly IOfferRepository offerRepository;        

        public OffersController(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;            
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Offer> Get()
        {            
            return offerRepository.Offers.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var offer = offerRepository.ReadId(id);
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
                    offerRepository.Create(offer);
                    return Ok(offer);
                }
            }
            

            return BadRequest();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Offer offer)
        {
            if (ModelState.IsValid)
            {
                var updatedOffer = offerRepository.ReadId(offer.Id);
                if (updatedOffer != null)
                {                    
                    //код с введением изменения

                    offerRepository.Update(updatedOffer);
                    return RedirectToAction("api/UpdateOfOffer/", updatedOffer.Id);
                }
                return NotFound();
            }
            return BadRequest(ModelState);            
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var offer = offerRepository.ReadId(id);
            if(offer != null)
            {
                offerRepository.Delete(offer);
                return Ok();
            }
            return NotFound();
        }
    }
}
