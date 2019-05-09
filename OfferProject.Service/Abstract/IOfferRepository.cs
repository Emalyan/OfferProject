using OfferProject.Data.Data;
using System.Collections.Generic;

namespace OfferProject.Service.Abstract
{
    public interface IOfferRepository
    {
        IEnumerable<Offer> Offers { get; }
        void Create(Offer offer);
        void Delete(Offer offer);
        void Update(Offer offer);
        IList<Offer> ReadAll();
        Offer ReadId(long id);
    }
}
