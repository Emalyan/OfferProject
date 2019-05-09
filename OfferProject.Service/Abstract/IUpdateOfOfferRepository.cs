using OfferProject.Data.Data;
using System.Collections.Generic;

namespace OfferProject.Service.Abstract
{
    public interface IUpdateOfOfferRepository
    {
        IEnumerable<UpdateOfOffer> UpdatesOfOffers { get; }
        void Create(UpdateOfOffer updateOfOffer);
        void Delete(UpdateOfOffer updateOfOffer);
        void Update(UpdateOfOffer updateOfOffer);
        IList<UpdateOfOffer> ReadAll();
        UpdateOfOffer ReadId(long id);
    }
}
