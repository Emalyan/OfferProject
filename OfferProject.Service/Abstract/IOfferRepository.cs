using OfferProject.Data.Data;
using System.Collections.Generic;

namespace OfferProject.Service.Abstract
{
    public interface IOfferRepository
    {
        IEnumerable<Offer> ReadAll();
        void Create(Offer offer);
        void Delete(Offer offer);
        void Update(Offer offer);        
        Offer ReadId(long id);         
    }
}
