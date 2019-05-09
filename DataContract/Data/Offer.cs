using System;

namespace OfferProject.Data.Data
{
    public class Offer
    {
        public long Id { get; set; }
        public DateTime DateOfCreate { get; set; }
        public long CustomerId { get; set; }
        public long ExplorerId { get; set; }
    }
}
