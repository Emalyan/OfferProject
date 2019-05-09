using OfferProject.Data.Data;
using OfferProject.Service.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace OfferProject.Service.Concrete
{
    public class OfferRepository : IOfferRepository
    {
        private readonly DataContext db;

        public OfferRepository(DataContext db)
        {
            this.db = db;
        }

        public IEnumerable<Offer> Offers
        {
            get { return db.Offers; }
        }

        public void Create(Offer offer)
        {
            db.Offers.Add(offer);
            db.SaveChanges();
        }

        public void Delete(Offer offer)
        {
            db.Offers.Remove(offer);
            db.SaveChanges();
        }

        public IList<Offer> ReadAll()
        {
            return db.Offers.ToList();
        }

        public Offer ReadId(long id)
        {
            return db.Offers.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Offer offer)
        {
            db.Offers.Update(offer);
            db.SaveChanges();
        }
    }
}
