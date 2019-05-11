using OfferProject.Data.Data;
using System.Collections.Generic;

namespace OfferProject.Service.Abstract
{
    public interface IUpdateOfOfferRepository
    {
        IEnumerable<UpdateOfOffer> ReadAll();
        void Create(UpdateOfOffer updateOfOffer);
        void Delete(UpdateOfOffer updateOfOffer);
        void Update(UpdateOfOffer updateOfOffer);        
        UpdateOfOffer ReadId(long id);
    }
}
