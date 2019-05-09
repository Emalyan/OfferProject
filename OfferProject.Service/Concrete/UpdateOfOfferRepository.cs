using OfferProject.Data.Data;
using OfferProject.Service.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace OfferProject.Service.Concrete
{
    public class UpdateOfOfferRepository : IUpdateOfOfferRepository
    {
        private readonly DataContext db;

        public UpdateOfOfferRepository(DataContext db)
        {
            this.db = db;
        }

        public IEnumerable<UpdateOfOffer> UpdatesOfOffers
        {
            get { return db.UpdatesOfOffer; }
        }

        public void Create(UpdateOfOffer updateOfOffer)
        {
            db.UpdatesOfOffer.Add(updateOfOffer);
            db.SaveChanges();
        }

        public void Delete(UpdateOfOffer updateOfOffer)
        {
            db.UpdatesOfOffer.Remove(updateOfOffer);
            db.SaveChanges();
        }

        public IList<UpdateOfOffer> ReadAll()
        {
            return db.UpdatesOfOffer.ToList();
        }

        public UpdateOfOffer ReadId(long id)
        {
            return db.UpdatesOfOffer.FirstOrDefault(x => x.Id == id);
        }

        public void Update(UpdateOfOffer updateOfOffer)
        {
            db.UpdatesOfOffer.Update(updateOfOffer);
            db.SaveChanges();
        }
    }
}
